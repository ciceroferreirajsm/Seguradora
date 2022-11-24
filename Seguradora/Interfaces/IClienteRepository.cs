using Seguradora.Entities;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IClienteRepository
    {
        Task<Cliente> InserirOuAtualizar(Cliente cliente);

        Task<Cliente> ObterPorId(int idCLiente);

        Task<bool> ExcluirCliente(int idCLiente);

        Task<Cliente> AtualizarCliente(Cliente cLiente);
    }
}
