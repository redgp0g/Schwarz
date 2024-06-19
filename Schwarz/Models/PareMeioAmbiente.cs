using Schwarz.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PareMeioAmbiente
	{
        [Key]
        public int IDPareMeioAmbiente{ get; set; }

        [ForeignKey("Funcionario")]
        [Display(Name = "Funcionário")]
        [Required(ErrorMessage = "O Funcionário é obrigatório!")]
        public int IDFuncionario { get; set; }
        public virtual Funcionario? Funcionario { get; set; }

        [Required(ErrorMessage = "A Data é obrigatória!")]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Local é obrigatório!")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O Desvio é obrigatório!")]
        public string Desvio { get; set; }

        [Display(Name = "Pontuação")]
        public int? Pontuacao { get; set; }
        public bool PontuacaoValida { get; set; } = true;

        [Display(Name = "Aprovação do Líder")]
        public EAprovacaoPare AprovacaoLider { get; set; } = EAprovacaoPare.SemAprovacao;
        public DateTime? DataAprovacaoLider { get; set; }

        [Display(Name = "Observações do Líder")]
        public string? ObservacoesLider { get; set; }

        [Display(Name = "Aprovação do Meio Ambiente")]
        public EAprovacaoPare AprovacaoMeioAmbiente { get; set; } = EAprovacaoPare.SemAprovacao;
        public DateTime? DataAprovacaoMeioAmbiente { get; set; }

        [Display(Name = "Observações do Meio Ambiente")]
        public string? ObservacoesMeioAmbiente { get; set; }
    }
}
