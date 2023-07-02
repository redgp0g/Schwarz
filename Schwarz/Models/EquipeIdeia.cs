
using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class EquipeIdeia : EquipeIdeiaRepository
	{

		[Key]
		public int IDEquipeIdeia { get; set; }
		[ForeignKey("SchwarzUser")]
		public string IDAspNetUser { get; set; }
		public virtual SchwarzUser? SchwarzUser { get; set; }

		[ForeignKey("Ideia")]
		public int IDIdeia { get; set; }
		public virtual Ideia Ideia { get; set; }
		public decimal? Reconhecimento { get; set; }

		public EquipeIdeia()
		{

		}
		public EquipeIdeia(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
		public EquipeIdeia(string iDAspNetUser, int iDIdeia)
		{
			IDAspNetUser = iDAspNetUser;
			IDIdeia = iDIdeia;
		}
	}
}
