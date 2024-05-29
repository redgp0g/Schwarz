using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class AlertaCota
    {

        [Key]
        public int IDAlertaCota { get; set; }

        [Required]
        [ForeignKey("RegistroCotas")]
        public int IDRegistroCotas { get; set; }
        public virtual RegistroCotas? RegistroCotas { get; set; }
        public string? AcaoContencao { get; set; }
        public DateTime? PrazoAcaoContencao { get; set; }
        public string? AcaoCorretiva { get; set; }
        public DateTime? PrazoAcaoCorretiva { get; set; }

        [Required]
        [ForeignKey("FuncionarioLider")]
        public int IDFuncionarioLider { get; set; }
        public virtual Funcionario? FuncionarioLider { get; set; }

        [ForeignKey("FuncionarioEspecialista")]
        public int? IDFuncionarioEspecialista { get; set; }
        public virtual Funcionario? FuncionarioEspecialista { get; set; }
        public DateTime? DataConfirmacaoProducao { get; set; }

        [ForeignKey("FuncionarioMetrologia")]
        public int? IDFuncionarioMetrologia { get; set; }
        public virtual Funcionario? FuncionarioMetrologia { get; set; }
        public bool? ConfirmacaoMetrologia { get; set; }
        public DateTime? DataConfirmacaoMetrologia { get; set; }
    }
}
