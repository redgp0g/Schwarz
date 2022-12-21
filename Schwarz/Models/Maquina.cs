

using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
    public class Maquina
    {
        [Key]
        public int IDDMaquina { get; set; }
        public string Nome { get; set; }
    }
}
