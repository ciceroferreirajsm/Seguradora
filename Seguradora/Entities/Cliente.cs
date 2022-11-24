﻿using System.ComponentModel.DataAnnotations;

namespace Seguradora.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string CpfCnpj { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Celular { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }
    }
}
