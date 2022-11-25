using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguradora.Entities
{
    public class Sinistro
    {
        [Key]
        public int IdSinistro { get; set; }

        [ForeignKey("IdVeiculo")]
        public int IdVeiculo { get; set; }

        [ForeignKey("IdVeiculo")]
        public int IdCLiente { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public string Endereco { get; set; }

        public string Descricao { get; set; }
    }
}
