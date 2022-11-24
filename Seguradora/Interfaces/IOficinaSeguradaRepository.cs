using Seguradora.Entities;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IOficinaSeguradaRepository
    {
        Task<OficinaSegurada> InserirOuAtualizar(OficinaSegurada cliente);

        Task<OficinaSegurada> ObterPorId(int idOficinaSegurada);

        Task<bool> ExcluirOficinaSegurada(int idOficinaSegurada);

        Task<OficinaSegurada> AtualizarOficinaSegurada(OficinaSegurada cLiente);
    }
}
