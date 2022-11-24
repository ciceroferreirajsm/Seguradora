using System.ComponentModel.DataAnnotations;

namespace Seguradora.Entities
{
    public class Veiculo
    {
        [Key]
        public int IdVeiculo { get; set; }

        public string Marca { get; set; }

        public string Ano { get; set; }

        public string Modelo { get; set; }

        public decimal ValorFipe { get; set; }

        public string Placa { get; set; }
    }
}
