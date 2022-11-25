using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemploAPI.Services
{
    public class SinistroService : ISinistroService
    {
        #region Propriedades

        private readonly ISinistroRepository _SinistroRepository;

        #endregion Propriedades

        #region Construtores

        public SinistroService(ISinistroRepository SinistroRepository)
        {
            _SinistroRepository = SinistroRepository ?? throw new ArgumentNullException(nameof(SinistroRepository));
        }

        public async Task<Sinistro> AdicionarSinistro(Sinistro Sinistro)
        {
            try
            {
                return await _SinistroRepository.InserirOuAtualizar(Sinistro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sinistro> ObterPorId(int idSinistro)
        {
            try
            {
                return await _SinistroRepository.ObterPorId(idSinistro);
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
                return await _SinistroRepository.ObterTodosSinistros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirSinistro(int idSinistro)
        {
            try
            {
                return await _SinistroRepository.ExcluirSinistro(idSinistro);
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
                return await _SinistroRepository.AtualizarSinistro(Sinistro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Construtores

    }
}
