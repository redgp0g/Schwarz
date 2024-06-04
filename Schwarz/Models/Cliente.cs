using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }
        public string Nome { get; set; } = string.Empty;

        public Cliente() { }
        public Cliente(int iDCliente, string nome)
        {
            IDCliente = iDCliente;
            Nome = nome;
        }
    }

}
