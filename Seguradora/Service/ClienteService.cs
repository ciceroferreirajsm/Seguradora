using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoExemploAPI.Services
{
    public class ClienteService : IClienteService
    {
        #region Propriedades

        private readonly IClienteRepository _clienteRepository;

        #endregion Propriedades

        #region Construtores

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            try
            {
                return await _clienteRepository.InserirOuAtualizar(cliente); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> ObterPorId(int idCLiente)
        {
            try
            {
                return await _clienteRepository.ObterPorId(idCLiente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Cliente>> ObterTodosClientes()
        {
            try
            {
                return await _clienteRepository.ObterTodosClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirCliente(int idCLiente)
        {
            try
            {
                return await _clienteRepository.ExcluirCliente(idCLiente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> AtualizarCliente(Cliente cLiente)
        {
            try
            {
                return await _clienteRepository.AtualizarCliente(cLiente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> LogarUsuario(Usuario usuario)
        {
            try
            {
                if(ValidarFormato(usuario.CpfCnpj))
                    return await _clienteRepository.LogarUsuario(usuario);

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarFormato(string cpfCnpj)
        {
            try
            {
                if (cpfCnpj.Length == 11)
                {
                    var reg = new Regex(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/");

                    if (!reg.IsMatch(cpfCnpj))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Formato do CPF inválido");
                    }
                }
                else if (cpfCnpj.Length == 14)
                {
                    var reg = new Regex(@"/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/");

                    if (!reg.IsMatch(cpfCnpj))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Formato do CNPJ inválido");
                    }
                }
                else
                {
                    throw new Exception("Formato do login inválido");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Construtores

    }
}
