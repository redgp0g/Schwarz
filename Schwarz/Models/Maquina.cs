

using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
    public class Maquina
    {
        [Key]
        public int IDMaquina { get; set; }
        public string Nome { get; set; }
    }
}
