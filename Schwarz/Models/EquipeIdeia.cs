
using Schwarz.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class EquipeIdeia
	{

		[Key]
		public int IDEquipeIdeia { get; set; }
		[ForeignKey("User")]
		public string IDUser { get; set; }
		public virtual SchwarzUser? User { get; set; }

		[ForeignKey("Ideia")]
		public int IDIdeia { get; set; }
		public virtual Ideia? Ideia { get; set; }

		public EquipeIdeia(string iDUser, int iDIdeia)
		{
			IDUser = iDUser;
			IDIdeia = iDIdeia;
		}
	}
}
