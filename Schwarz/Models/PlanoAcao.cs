using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PlanoAcao
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

        private readonly SchwarzContext _context;
        public PlanoAcao()
		{

		}
		public PlanoAcao(SchwarzContext contexto)
		{
			_context = contexto;
		}

	}
}
