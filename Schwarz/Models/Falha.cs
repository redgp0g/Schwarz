using Microsoft.EntityFrameworkCore;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;

namespace Schwarz.Models
{
	public class Falha : FalhaRepository
	{
		[Key]
		public int IDFalha { get; set; }
		public string Identificacao{ get; set; }
		public int Codigo { get; set; }
		public string Descricao { get; set; }


		public Falha()
		{

		}
		public Falha(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
