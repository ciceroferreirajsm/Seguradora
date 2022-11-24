using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoExemploAPI.Services;
using Seguradora.Data;
using Seguradora.Intefaces;
using Seguradora.Repository;

namespace Seguradora
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Seguradora PIM",
                    Version = "v1",
                    Description = "API Seguradora PIM",
                    Contact = new OpenApiContact
                    {
                        Name = "PIM",
                        Email = "",
                    }
                });
            });            

            services.AddDbContext<SeguradoraContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SeguradoraContext")));

            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IVeiculoService, VeiculoService>();
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
            services.AddTransient<IOficinaSeguradaService, OficinaSeguradaService>();
            services.AddTransient<IOficinaSeguradaRepository, OficinaSeguradaRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "API Seguradora PIM");
                option.RoutePrefix = "swagger";
                option.DocExpansion(DocExpansion.None);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
