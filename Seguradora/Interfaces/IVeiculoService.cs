using Seguradora.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IVeiculoService
    {
        Task<Veiculo> AdicionarVeiculo(Veiculo veiculo);

        Task<Veiculo> ObterPorId(int idVeiculo);

        Task<List<Veiculo>> ObterTodosVeiculos();

        Task<bool> ExcluirVeiculo(int idVeiculo);

        Task<Veiculo> AtualizarVeiculo(Veiculo veiculo);

    }
}
