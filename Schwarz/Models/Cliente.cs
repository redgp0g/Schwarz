using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
	public class Cliente : ClienteRepository
	{
		[Key]
		public int IDCliente { get; set; }
		public string Nome { get; set; }

		public Cliente()
		{

		}
		public Cliente(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
