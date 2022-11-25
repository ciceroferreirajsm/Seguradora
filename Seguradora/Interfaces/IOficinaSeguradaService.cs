using Seguradora.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IOficinaSeguradaService
    {
        Task<OficinaSegurada> AdicionarOficinaSegurada(OficinaSegurada OficinaSegurada);

        Task<OficinaSegurada> ObterPorId(int idOficinaSegurada);

        Task<List<OficinaSegurada>> ObterTodasOficinaSeguradas();

        Task<bool> ExcluirOficinaSegurada(int idOficinaSegurada);

        Task<OficinaSegurada> AtualizarOficinaSegurada(OficinaSegurada OficinaSegurada);

    }
}
