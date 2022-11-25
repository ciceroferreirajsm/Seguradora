using Seguradora.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface ISinistroService
    {
        Task<Sinistro> AdicionarSinistro(Sinistro Sinistro);

        Task<Sinistro> ObterPorId(int idSinistro);

        Task<List<Sinistro>> ObterTodosSinistros();

        Task<bool> ExcluirSinistro(int idSinistro);

        Task<Sinistro> AtualizarSinistro(Sinistro Sinistro);

    }
}
