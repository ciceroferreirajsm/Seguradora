using System.ComponentModel.DataAnnotations;

namespace Seguradora.Entities
{
    public class OficinaSegurada
    {
        [Key]
        public int IdOficinaSegurada { get; set; }

        public string Endereco { get; set; }

        public bool Credenciada { get; set; }
    }
}
