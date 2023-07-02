using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PlanoControle : PlanoControleRepository
	{
		[Key]
		public int IDPlanoControle { get; set; }
		[Display(Name = "Revisão")]
		public int Revisao { get; set; }
        [Display(Name = "Data de Origem")]
        public DateTime DataOrigem { get; set; }
        [Display(Name = "Data de Atualização")]
        public DateTime DataAtualizacao { get; set; }
		public string Status{ get; set; }
        public string Produto{ get; set; }
		public string Cliente { get; set; }
		public string Processo { get; set; }
        [Display(Name = "Código Interno")]
        public int CodigoInterno { get; set; }
        [Display(Name = "Código / Revisão do Cliente")]
        public string CodigoCliente { get; set; }
        [Display(Name = "N° do Fluxo")]
        public int NFluxo { get; set; }
		[Display(Name = "Observações")]
		public string? Observacoes { get; set; }
		[ForeignKey("SchwarzUserElaborador")]
        [Display(Name = "Elaborador")]
        public string IDSchwarzUserElaborador { get; set; }
		public virtual SchwarzUser? SchwarzUserElaborador { get; set; }
		[ForeignKey("SchwarzUserAprovador")]
        [Display(Name = "Aprovador")]
        public string IDSchwarzUserAprovador { get; set; }
		public virtual SchwarzUser? SchwarzUserAprovador { get; set; }

		public PlanoControle()
		{

		}
		public PlanoControle(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
