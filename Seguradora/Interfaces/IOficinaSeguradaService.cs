using Seguradora.Entities;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IOficinaSeguradaService
    {
        Task<OficinaSegurada> AdicionarOficinaSegurada(OficinaSegurada cliente);

        Task<OficinaSegurada> ObterPorId(int idOficinaSegurada);

        Task<bool> ExcluirOficinaSegurada(int idOficinaSegurada);

        Task<OficinaSegurada> AtualizarOficinaSegurada(OficinaSegurada cLiente);
    }
}
