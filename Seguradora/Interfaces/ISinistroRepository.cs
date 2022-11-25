using Seguradora.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface ISinistroRepository
    {
        Task<Sinistro> InserirOuAtualizar(Sinistro cliente);

        Task<Sinistro> ObterPorId(int idSinistro);

        Task<List<Sinistro>> ObterTodosSinistros();

        Task<bool> ExcluirSinistro(int idSinistro);

        Task<Sinistro> AtualizarSinistro(Sinistro cLiente);
    }
}
