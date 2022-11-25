
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SinistroController : ControllerBase
    {

        private readonly ILogger<SinistroController> _logger;

        private readonly ISinistroService _SinistroService;

        public SinistroController(ILogger<SinistroController> logger, ISinistroService SinistroService)
        {
            _logger = logger;
            _SinistroService = SinistroService;
        }

        [HttpGet("ObterSinistroPorId/{IdSinistro}")]
        public async Task<IActionResult> ObterSinistroPorId(int IdSinistro)
        {
            try
            {
                Sinistro retorno = await _SinistroService.ObterPorId(IdSinistro);

                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest("Object was Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ObterSinistros")]
        public async Task<IActionResult> ObterSinistros()
        {
            try
            {
                var retorno = await _SinistroService.ObterTodosSinistros();

                if (retorno != null && retorno.Any())
                {
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest("Não existem Sinistros cadastrados!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AdicionarSinistro")]
        public async Task<IActionResult> AdicionarSinistro([FromBody] Sinistro Sinistro)
        {
            try
            {
                Sinistro retorno = await _SinistroService.AdicionarSinistro(Sinistro);

                if (retorno != null)
                {
                    return StatusCode(201);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("ExcluirSinistro/{idSinistro}")]
        public async Task<IActionResult> ExcluirSinistro(int idSinistro)
        {
            try
            {
                bool SinistroExcluido = await _SinistroService.ExcluirSinistro(idSinistro);

                if (SinistroExcluido)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Object was Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("AtualizarSinistro")]
        public async Task<IActionResult> AtualizarSinistro(Sinistro Sinistro)
        {
            try
            {
                Sinistro SinistroAtualizado = await _SinistroService.AtualizarSinistro(Sinistro);

                if (SinistroAtualizado != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Object was Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
