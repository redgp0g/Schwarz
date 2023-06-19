using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PlanoControleCota : PlanoControleRepository
	{
		[Key]
		public int IDPlanoControleCota { get; set; }
		[ForeignKey("PlanoControle")]
		public int IDPlanoControle { get; set; }
		public virtual PlanoControle PlanoControle{ get; set; }
		[ForeignKey("Cota")]
		public int IDCota{ get; set; }
		public virtual Cota Cota { get; set; }

		public PlanoControleCota()
		{

		}
		public PlanoControleCota(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
