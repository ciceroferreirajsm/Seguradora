using Microsoft.EntityFrameworkCore;
using Seguradora.Data;
using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.Repository
{
    public class SinistroRepository : ISinistroRepository
    {
        private readonly SeguradoraContext _context;

        public SinistroRepository(SeguradoraContext context)
        {
            _context = context;
        }

        public async Task<Sinistro> InserirOuAtualizar(Sinistro Sinistro)
        {
            try
            {
                Sinistro obj = _context.Sinistro.FirstOrDefault(x => x.IdSinistro == Sinistro.IdSinistro);

                if (obj == null)
                {
                    await _context.Sinistro.AddAsync(Sinistro);

                    _context.SaveChanges();

                    return Sinistro;
                }
                else
                {
                    obj = await AtualizarSinistro(Sinistro);

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sinistro> ObterPorId(int IdSinistro)
        {
            try
            {
                return _context.Sinistro.FirstOrDefault(x => x.IdSinistro == IdSinistro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Sinistro>> ObterTodosSinistros()
        {
            try
            {
                return _context.Sinistro.OrderBy(x => x.IdSinistro).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> ExcluirSinistro(int IdSinistro)
        {
            try
            {
                Sinistro obj = _context.Sinistro.FirstOrDefault(x => x.IdSinistro == IdSinistro);

                _context.Sinistro.Remove(obj);

                _context.SaveChanges();

                obj = _context.Sinistro.FirstOrDefault(x => x.IdSinistro == IdSinistro);

                if (obj == null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sinistro> AtualizarSinistro(Sinistro Sinistro)
        {
            try
            {
                Sinistro obj = await _context.Sinistro.AsNoTracking().FirstOrDefaultAsync(x => x.IdSinistro == Sinistro.IdSinistro);

                if (obj == null)
                {
                    return obj;
                }
                else
                {
                    obj = new Sinistro()
                    {
                        IdSinistro = Sinistro.IdSinistro,
                        IdCLiente = Sinistro.IdCLiente,
                        IdVeiculo = Sinistro.IdVeiculo,
                        Data = Sinistro.Data,
                        Descricao = Sinistro.Descricao,
                        Endereco = Sinistro.Endereco,
                        Valor = Sinistro.Valor
                    };

                    _context.Sinistro.Update(obj);

                    _context.SaveChanges();

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}