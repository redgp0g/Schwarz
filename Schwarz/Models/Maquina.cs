

using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
    public class Maquina : MaquinaRepository
    {
        [Key]
        public int IDMaquina { get; set; }
        public string Nome { get; set; }

		public Maquina()
		{

		}
		public Maquina(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
