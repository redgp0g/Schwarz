using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PareSeguranca
	{
        [Key]
        public int IDPareSeguranca { get; set; }
        [ForeignKey("Funcionário")]
        [Display(Name = "Funcionario")]
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

        [Display(Name = "Ordem de Serviço")]
        [Required(ErrorMessage = "A Ordem de Serviço é obrigatória!")]
        public string OrdemServico { get; set; }

        [Display(Name = "Aprovação do Líder")]
        public bool? AprovacaoLider { get; set; }
        public DateTime? DataAprovacaoLider { get; set; }

        [Display(Name = "Observações do Líder")]
        public string? ObservacoesLider { get; set; }

        [Display(Name = "Aprovação da Segurança")]
        public bool? AprovacaoSeguranca { get; set; }
        public DateTime? DataAprovacaoSeguranca { get; set; }

        [Display(Name = "Observações do Segurança")]
        public string? ObservacoesSeguranca { get; set; }
        public int? ClassificacaoGUT { get; set; }
        public virtual ICollection<PareSegurancaFoto>? PareSegurancaFotos { get; set; }
        
        [NotMapped]
        [Required(ErrorMessage = "É obrigatório pelo menos uma Foto!")]
        [Display(Name = "Fotos do Local")]
        public List<IFormFile>? Fotos { get; set; }

    }
}
