using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class FluxoOperacao : FluxoOperacaoRepository
	{
		[Key]
		public int IDFluxoOperacao { get; set; }
		[ForeignKey("Fluxo")]
		public int IDFluxo { get; set; }
		public virtual Fluxo? Fluxo { get; set; }
		[ForeignKey("Operacao")]
		public int IDOperacao { get; set; }
		public virtual Operacao? Operacao { get; set; }
		public FluxoOperacao()
		{

		}
		public FluxoOperacao(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
