using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Threading.Tasks;

namespace ProjetoExemploAPI.Services
{
    public class VeiculoService : IVeiculoService
    {
        #region Propriedades

        private readonly IVeiculoRepository _VeiculoRepository;

        #endregion Propriedades

        #region Construtores

        public VeiculoService(IVeiculoRepository VeiculoRepository)
        {
            _VeiculoRepository = VeiculoRepository ?? throw new ArgumentNullException(nameof(VeiculoRepository));
        }

        public async Task<Veiculo> AdicionarVeiculo(Veiculo Veiculo)
        {
            try
            {
                return await _VeiculoRepository.InserirOuAtualizar(Veiculo); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Veiculo> ObterPorId(int idVeiculo)
        {
            try
            {
                return await _VeiculoRepository.ObterPorId(idVeiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirVeiculo(int idVeiculo)
        {
            try
            {
                return await _VeiculoRepository.ExcluirVeiculo(idVeiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Veiculo> AtualizarVeiculo(Veiculo Veiculo)
        {
            try
            {
                return await _VeiculoRepository.AtualizarVeiculo(Veiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Construtores

    }
}
