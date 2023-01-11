using Microsoft.EntityFrameworkCore;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;

namespace Schwarz.Models
{
	public class FSP : FSPRepository
	{
		[Key]
		public int IDBoleto { get; set; }

		[Column("Boleto")]
		[Required(ErrorMessage = "Digite o Boleto")]
		[Display(Name = "Boleto")]
		public float Numeracao { get; set; }

		[Required(ErrorMessage = "Digite a Cota")]
		public float Cota { get; set; }

		[Display(Name = "Tolerância")]
		[Required(ErrorMessage = "Digite a Tolerância")]
		public string Tolerancia { get; set; }

		[Display(Name = "Característica Especial")]
		public string? Caracteristica { get; set; }
		public virtual ICollection<DesenhoBoleto>? DesenhoBoletos { get; set; }

		public FSP()
		{

		}
		public FSP(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
