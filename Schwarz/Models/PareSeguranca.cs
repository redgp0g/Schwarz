using Schwarz.Enums;
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
        [Required(ErrorMessage = "A Ordem de Serviço é obrigatória!")]
        public string OrdemServico { get; set; }

        [ForeignKey("FuncionarioLider")]
        public int IDFuncionarioLider { get; set; }
        public virtual Funcionario? FuncionarioLider { get; set; }

        [Display(Name = "Ação do Líder")]
        public string? AcaoLider { get; set; }

        [Display(Name = "Prazo da Ação do Líder")]
        public DateTime? PrazoAcaoLider { get; set; }

        [Display(Name = "Foi Realizado?")]
        public bool Realizado { get; set; } = false;

        [ForeignKey("FuncionarioSeguranca")]
        public int? IDFuncionarioSeguranca { get; set; }
        public virtual Funcionario? FuncionarioSeguranca { get; set; }

        [Display(Name = "Observações da Segurança")]
        public string? ObservacoesSeguranca { get; set; }
        public DateTime? DataValidado { get; set; }
        public int? ClassificacaoGUT { get; set; }

        [Display(Name = "Pontuação")]
        public int? Pontuacao { get; set; }
        public bool PontuacaoValida { get; set; } = true;
        public virtual ICollection<PareSegurancaFoto>? PareSegurancaFotos { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "É obrigatório pelo menos uma Foto!")]
        [Display(Name = "Fotos do Local")]
        public List<IFormFile>? Fotos { get; set; }

    }
}
