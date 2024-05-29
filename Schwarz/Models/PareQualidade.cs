using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PareQualidade
	{
		[Key]
		public int IDPareQualidade { get; set; }

		[ForeignKey("Funcionario")]
		[Display(Name = "Funcionário")]
		[Required(ErrorMessage = "Selecione o Funcionário!")]
		public int IDFuncionario { get; set; }
		public virtual Funcionario Funcionario { get; set; } = new Funcionario();

		[ForeignKey("Falha")]
		[Display(Name = "Falha")]
		public int? IDFalha { get; set; }
		public virtual Falha? Falha { get; set; }

		[Display(Name = "Descrição da Falha")]
		public string? DescricaoFalha{ get; set; }

		[Required(ErrorMessage = "A Data é obrigatória!")]
		public DateTime Data { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Selecione o Setor onde ocorreu!")]
		public string Setor { get; set; } = string.Empty;

		[Required(ErrorMessage = "O Código é obrigatório!")]
		[Display(Name = "Código do Item")]
		[MinLength(9, ErrorMessage = "O código deve ter 9 digítos!")]
		public string CodigoItem { get; set; }
		public string CodigoItem { get; set; } = string.Empty;

		[Required(ErrorMessage = "A Quantidade é obrigatória!")]
		[Display(Name = "Quantidade Bloqueada")]
		public int QuantidadeBloqueada { get; set; }
        public bool? AprovacaoLider { get; set; }
        public DateTime? DataAprovacaoLider { get; set; }
        
		[Display(Name = "Observações do Líder")]
		public string? ObservacoesLider { get; set; }
		public bool? AprovacaoQualidade { get; set; }
		public DateTime? DataAprovacaoQualidade{ get; set; }

		[Display(Name = "Observações da Qualidade")]
		public string? ObservacoesQualidade { get; set; }

		[Display(Name = "Pontuação")]
		public int? Pontuacao { get; set; }
		public bool PontuacaoValida { get; set; } = true;

		[NotMapped]
		public string DataFormatada => Data.ToString("dd/MM/yyyy");

		private readonly SchwarzContext _context;
		public PareQualidade(SchwarzContext contexto)
		{
			_context = contexto;
		}
		public PareQualidade()
		{
		}
	}
}
