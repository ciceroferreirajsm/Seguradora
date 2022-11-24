using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Threading.Tasks;

namespace ProjetoExemploAPI.Services
{
    public class OficinaSeguradaService : IOficinaSeguradaService
    {
        #region Propriedades

        private readonly IOficinaSeguradaRepository _OficinaSeguradaRepository;

        #endregion Propriedades

        #region Construtores

        public OficinaSeguradaService(IOficinaSeguradaRepository OficinaSeguradaRepository)
        {
            _OficinaSeguradaRepository = OficinaSeguradaRepository ?? throw new ArgumentNullException(nameof(OficinaSeguradaRepository));
        }

        public async Task<OficinaSegurada> AdicionarOficinaSegurada(OficinaSegurada OficinaSegurada)
        {
            try
            {
                return await _OficinaSeguradaRepository.InserirOuAtualizar(OficinaSegurada); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OficinaSegurada> ObterPorId(int idOficinaSegurada)
        {
            try
            {
                return await _OficinaSeguradaRepository.ObterPorId(idOficinaSegurada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirOficinaSegurada(int idOficinaSegurada)
        {
            try
            {
                return await _OficinaSeguradaRepository.ExcluirOficinaSegurada(idOficinaSegurada);
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
                return await _OficinaSeguradaRepository.AtualizarOficinaSegurada(OficinaSegurada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Construtores

    }
}
