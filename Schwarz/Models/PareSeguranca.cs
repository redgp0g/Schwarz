using Schwarz.Statics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class PareSeguranca
    {
        [Key]
        public int IDPareSeguranca { get; set; }
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

        [Display(Name = "Ordem de Serviço")]
        public string? OrdemServico { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = StatusPare.EmAnalise;

        [Display(Name = "Líder")]
        [ForeignKey("FuncionarioLider")]
        public int IDFuncionarioLider { get; set; }
        public virtual Funcionario? FuncionarioLider { get; set; }

        [Display(Name = "Ação do Líder")]
        public string? AcaoLider { get; set; }

        [Display(Name = "Prazo da Ação do Líder")]
        public DateTime? PrazoAcaoLider { get; set; }

        [Display(Name = "Data de Conclusão")]
        public DateTime? DataConclusao { get; set; }

        [Display(Name = "Observações do Líder")]
        public string? ObservacoesLider{ get; set; }

        [ForeignKey("FuncionarioSeguranca")]
        public int? IDFuncionarioSeguranca { get; set; }
        public virtual Funcionario? FuncionarioSeguranca { get; set; }

        [Display(Name = "Observações da Segurança")]
        public string? ObservacoesSeguranca { get; set; }

        [Display(Name = "Data de Validação")]
        public DateTime? DataValidado { get; set; }

        public int? ClassificacaoGUT { get; set; }

        [Display(Name = "Pontuação")]
        public int? Pontuacao { get; set; }
        public bool PontuacaoValida { get; set; } = true;
        public virtual ICollection<PareSegurancaFoto>? PareSegurancaFotos { get; set; }

        [NotMapped]
        [Display(Name = "Fotos do Local")]
        public List<IFormFile>? Fotos { get; set; }

    }
}
