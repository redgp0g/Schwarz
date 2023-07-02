

using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PlanoAcao : PlanoAcaoRepository
	{

		[Key]
		public int IDPlanoAcao { get; set; }

		[ForeignKey("SchwarzUser")]
		public string IDSchwarzUser { get; set; }
		public virtual SchwarzUser? SchwarzUser{ get; set; }

		[ForeignKey("FSP")]
		public int IDFSP { get; set; }
		public virtual FSP? FSP{ get; set; }
		public string Descricao { get; set; }
		public DateTime Prazo { get; set; }
		public string Status { get; set; }

		public PlanoAcao()
		{

		}
		public PlanoAcao(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
