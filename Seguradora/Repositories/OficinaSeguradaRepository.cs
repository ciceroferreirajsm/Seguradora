
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
    public class OficinaSeguradaRepository : IOficinaSeguradaRepository
    {
        private readonly SeguradoraContext _context;

        public OficinaSeguradaRepository(SeguradoraContext context)
        {
            _context = context;
        }

        public async Task<OficinaSegurada> InserirOuAtualizar(OficinaSegurada OficinaSegurada)
        {
            try
            {
                OficinaSegurada obj = _context.OficinaSegurada.FirstOrDefault(x => x.IdOficinaSegurada == OficinaSegurada.IdOficinaSegurada);

                if (obj == null)
                {
                    await _context.OficinaSegurada.AddAsync(OficinaSegurada);

                    _context.SaveChanges();

                    return OficinaSegurada;
                }
                else
                {
                    obj = await AtualizarOficinaSegurada(OficinaSegurada);

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OficinaSegurada> ObterPorId(int IdOficinaSegurada)
        {
            try
            {
                return _context.OficinaSegurada.FirstOrDefault(x => x.IdOficinaSegurada == IdOficinaSegurada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OficinaSegurada>> ObterTodosOficinaSeguradas()
        {
            try
            {
                return _context.OficinaSegurada.OrderBy(x => x.IdOficinaSegurada).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirOficinaSegurada(int IdOficinaSegurada)
        {
            try
            {
                OficinaSegurada obj = _context.OficinaSegurada.FirstOrDefault(x => x.IdOficinaSegurada == IdOficinaSegurada);

                _context.OficinaSegurada.Remove(obj);

                _context.SaveChanges();

                obj = _context.OficinaSegurada.FirstOrDefault(x => x.IdOficinaSegurada == IdOficinaSegurada);

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

        public async Task<OficinaSegurada> AtualizarOficinaSegurada(OficinaSegurada OficinaSegurada)
        {
            try
            {
                OficinaSegurada obj = await _context.OficinaSegurada.AsNoTracking().FirstOrDefaultAsync(x => x.IdOficinaSegurada == OficinaSegurada.IdOficinaSegurada);

                if (obj == null)
                {
                    return obj;
                }
                else
                {
                    obj = new OficinaSegurada()
                    {
                        IdOficinaSegurada = OficinaSegurada.IdOficinaSegurada,
                        Credenciada = OficinaSegurada.Credenciada,
                        Endereco = OficinaSegurada.Endereco
                    };

                    _context.OficinaSegurada.Update(obj);

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