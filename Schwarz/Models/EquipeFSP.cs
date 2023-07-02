
using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class EquipeFSP : EquipeFSPRepository
	{

		[Key]
		public int IDEquipeFSP { get; set; }
		[ForeignKey("SchwarzUser")]
		public string IDSchwarzUser { get; set; }
		public virtual SchwarzUser? SchwarzUser { get; set; }

		[ForeignKey("FSP")]
		public int IDFSP { get; set; }
		public virtual FSP? FSP{ get; set; }

		public EquipeFSP()
		{

		}
		public EquipeFSP(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
