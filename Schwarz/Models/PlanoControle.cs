using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PlanoControle
	{
		[Key]
		public int IDPlanoControle { get; set; }

        [Required(ErrorMessage = "A Revisão é obrigatória")]
        [Display(Name = "Revisão")]
		public int Revisao { get; set; }

        [Display(Name = "Descrição da Revisão")]
        public string? DescricaoRevisao { get; set; }

        [Required(ErrorMessage = "O Código do Documento é obrigatório")]
        [Display(Name = "Código")]
        public string CodigoDocumento { get; set; }

        [Required(ErrorMessage = "A Data de Origem é obrigatória")]
        [Display(Name = "Data de Origem")]
        public DateTime DataOrigem { get; set; }

        [Required(ErrorMessage = "A Data de Atualização é obrigatória")]
        [Display(Name = "Data de Atualização")]
        public DateTime DataAtualizacao { get; set; }

        [Required(ErrorMessage = "O Status é obrigatório")]
        public string Status{ get; set; }

        [Required(ErrorMessage = "O Produto é obrigatório")]
        public string Produto{ get; set; }

        [Required(ErrorMessage = "O Cliente é obrigatório")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "O Processo é obrigatório")]
        public string Processo { get; set; }

        [Required(ErrorMessage = "O Código do Interno é obrigatório")]
        [Display(Name = "Código Interno")]
        public int CodigoInterno { get; set; }

        [Required(ErrorMessage = "O Código do Cliente é obrigatório")]
        [Display(Name = "Código / Revisão do Cliente")]
        public string CodigoCliente { get; set; }

        [Required(ErrorMessage = "O Número do Fluxo é obrigatório")]
        [Display(Name = "N° do Fluxo")]
        public int NumeroFluxo { get; set; }

		[Display(Name = "Observações")]
		public string? Observacoes { get; set; }

        [Required(ErrorMessage = "Selecione o funcionário")]
        [ForeignKey("FuncionarioElaborador")]
        [Display(Name = "Elaborador")]
        public int IDFuncionarioElaborador { get; set; }
		public virtual Funcionario? FuncionarioElaborador { get; set; }

		[Required(ErrorMessage = "Selecione o funcionário")]
		[ForeignKey("FuncionarioAprovador")]
        [Display(Name = "Aprovador")]
        public int IDFuncionarioAprovador { get; set; }
		public virtual Funcionario? FuncionarioAprovador { get; set; }
		public virtual ICollection<Cota>? Cotas { get; set; }


        private readonly SchwarzContext _context;
        public PlanoControle()
		{

		}
		public PlanoControle(SchwarzContext contexto)
		{
			_context = contexto;
		}

	}
}
