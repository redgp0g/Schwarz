using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class LicaoAprendida
    {

        [Key]
        public int IDLicaoAprendida { get; set; }

        [Display(Name = "Evento")]
        [Required(ErrorMessage = "O Evento é obrigatório!")]
        [ForeignKey("Falha")]
        public int IDFalha { get; set; }
        public virtual Falha? Falha { get; set; }

        [ForeignKey("Funcionario")]
        public int IDFuncionario { get; set; }
        public virtual Funcionario? Funcionario { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Processo é obrigatório!")]
        public string Processo { get; set; }

        [Display(Name = "Código Interno")]
        [Required(ErrorMessage = "O Codigo Interno é obrigatório!")]
        public int CodigoInterno { get; set; }

        [Required(ErrorMessage = "O Motivo é obrigatório!")]
        public string Motivo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A Lição Aprendida é obrigatória!")]
        public string Descricao { get; set; }

        public LicaoAprendida() { }
    }
}
