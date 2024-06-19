using Schwarz.Data;
using Schwarz.Enums;
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
		public virtual Funcionario? Funcionario { get; set; }

		[Display(Name = "Descrição")]
		public string Descricao { get; set; }

		[Required(ErrorMessage = "A Data é obrigatória!")]
		public DateTime Data { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Selecione o Setor onde ocorreu!")]
		public string Setor { get; set; }

		[Required(ErrorMessage = "O Código é obrigatório!")]
		[Display(Name = "Código do Item")]
		[MinLength(9, ErrorMessage = "O código deve ter no mínimo 9 digítos!")]
		[MaxLength(9, ErrorMessage = "O código deve ter no máximo 9 digítos!")]
		public string CodigoItem { get; set; }

		[Required(ErrorMessage = "A Quantidade é obrigatória!")]
		[Display(Name = "Quantidade Bloqueada")]
		public int QuantidadeBloqueada { get; set; }

		[Display(Name = "Aprovação do Líder")]
		public EAprovacaoPare AprovacaoLider { get; set; } = EAprovacaoPare.SemAprovacao;

		[Display(Name = "Observações do Líder")]
		public string? ObservacoesLider { get; set; }

		[Display(Name = "Aprovação da Qualidade")]
		public EAprovacaoPare AprovacaoQualidade { get; set; } = EAprovacaoPare.SemAprovacao;

		[Display(Name = "Observações da Qualidade")]
		public string? ObservacoesQualidade { get; set; }

		[Display(Name = "Pontuação")]
		public int? Pontuacao { get; set; }
		public bool PontuacaoValida { get; set; } = true;

		[NotMapped]
		public string DataFormatada => Data.ToString("dd/MM/yyyy");
	}
}
