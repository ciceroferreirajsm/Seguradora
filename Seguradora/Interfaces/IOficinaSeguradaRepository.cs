using Seguradora.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IOficinaSeguradaRepository
    {
        Task<OficinaSegurada> InserirOuAtualizar(OficinaSegurada cliente);

        Task<OficinaSegurada> ObterPorId(int idOficinaSegurada);

        Task<List<OficinaSegurada>> ObterTodosOficinaSeguradas();

        Task<bool> ExcluirOficinaSegurada(int idOficinaSegurada);

        Task<OficinaSegurada> AtualizarOficinaSegurada(OficinaSegurada cLiente);
    }
}
