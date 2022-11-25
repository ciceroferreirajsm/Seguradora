using System.ComponentModel.DataAnnotations;

namespace Seguradora.Entities
{
    public class Usuario
    {
        public string CpfCnpj { get; set; }

        public string Senha { get; set; }

    }
}
