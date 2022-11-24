using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
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

        #endregion Construtores

    }
}
