
using Schwarz.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class EquipeIdeia
	{
		[Key]
		public int IDEquipeIdeia { get; set; }
		[ForeignKey("AspNetUser")]
		public string IdUser { get; set; }
		public virtual SchwarzUser User { get; set; }


		EquipeIdeia() { }
		public void GetTeste()
		{
			EquipeIdeia User = new();
		}

	}
}
