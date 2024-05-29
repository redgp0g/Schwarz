using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class LicaoAprendida
    {

        [Key]
        public int IDLicaoAprendida { get; set; }

        [Required(ErrorMessage = "O campo Planejado é obrigatório!")]
        public string Planejado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Realizado é obrigatório!")]
        public string Realizado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Motivo é obrigatório!")]
        public string Motivo { get; set; } = string.Empty;

        [ForeignKey("Funcionario")]
        public int IDFuncionario { get; set; }
        public virtual Funcionario? Funcionario { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Processo é obrigatório!")]
        public string Processo { get; set; } = string.Empty;

        [Display(Name = "Nome da Peça")]
        [Required(ErrorMessage = "O nome da peça é obrigatória!")]
        public string NomePeca { get; set; } = string.Empty;

        [Display(Name = "Código Interno")]
        [Required(ErrorMessage = "O Código Interno é obrigatório!")]
        public string CodigoInterno { get; set; } = string.Empty;

        [Display(Name = "Lição Aprendida")]
        [Required(ErrorMessage = "A Lição Aprendida é obrigatória!")]
        public string Descricao { get; set; } = string.Empty;

        [Display(Name = "Positivo/Negativo")]
        public bool Positivo { get; set; }

        public virtual ICollection<LicaoAprendidaAnexo>? LicaoAprendidaAnexos { get; set; }

        [NotMapped]
        public List<IFormFile>? Arquivos { get; set; }
    }
}
