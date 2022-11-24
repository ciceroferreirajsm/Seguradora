using Seguradora.Entities;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> InserirOuAtualizar(Veiculo cliente);

        Task<Veiculo> ObterPorId(int idVeiculo);

        Task<bool> ExcluirVeiculo(int idVeiculo);

        Task<Veiculo> AtualizarVeiculo(Veiculo cLiente);
    }
}
