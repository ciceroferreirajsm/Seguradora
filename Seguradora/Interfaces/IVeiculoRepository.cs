using Seguradora.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> InserirOuAtualizar(Veiculo cliente);

        Task<Veiculo> ObterPorId(int idVeiculo);

        Task<List<Veiculo>> ObterTodosVeiculos();

        Task<bool> ExcluirVeiculo(int idVeiculo);

        Task<Veiculo> AtualizarVeiculo(Veiculo cLiente);
    }
}
