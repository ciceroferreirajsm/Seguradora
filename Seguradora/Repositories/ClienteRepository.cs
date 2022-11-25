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
    public class ClienteRepository : IClienteRepository
    {
        private readonly SeguradoraContext _context;

        public ClienteRepository(SeguradoraContext context)
        {
            _context = context;
        }

        public async Task<Cliente> InserirOuAtualizar(Cliente Cliente)
        {
            try
            {
                Cliente obj = _context.Cliente.FirstOrDefault(x => x.IdCliente == Cliente.IdCliente);

                if (obj == null)
                {
                    await _context.Cliente.AddAsync(Cliente);

                    _context.SaveChanges();

                    return Cliente;
                }
                else
                {
                    obj = await AtualizarCliente(Cliente);

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> ObterPorId(int IdCliente)
        {
            try
            {
                return _context.Cliente.FirstOrDefault(x => x.IdCliente == IdCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirCliente(int IdCliente)
        {
            try
            {
                Cliente obj = _context.Cliente.FirstOrDefault(x => x.IdCliente == IdCliente);

                _context.Cliente.Remove(obj);

                _context.SaveChanges();

                obj = _context.Cliente.FirstOrDefault(x => x.IdCliente == IdCliente);

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

        public async Task<Cliente> AtualizarCliente(Cliente Cliente)
        {
            try
            {
                Cliente obj = await _context.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.IdCliente == Cliente.IdCliente);

                if (obj == null)
                {
                    return obj;
                }
                else
                {
                    obj = new Cliente()
                    {
                        IdCliente = Cliente.IdCliente,
                        Nome = Cliente.Nome,
                        Celular = Cliente.Celular,
                        CEP = Cliente.CEP,
                        Email = Cliente.Email,
                        Endereco = Cliente.Endereco,
                        Senha = Cliente.Senha
                    };

                    _context.Cliente.Update(obj);

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