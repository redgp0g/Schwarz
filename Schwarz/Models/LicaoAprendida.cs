using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class LicaoAprendida
    {

        [Key]
        public int IDLicaoAprendida { get; set; }

        [Required(ErrorMessage = "O campo Fonte é obrigatório!")]
        public string Fonte { get; set; } = "Schwarz";
        
        [Required(ErrorMessage = "O campo Planejado é obrigatório!")]
        public string Planejado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Realizado é obrigatório!")]
        public string Realizado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Motivo é obrigatório!")]
        public string Motivo { get; set; } = string.Empty;

        [Display(Name = "Funcionário")]
        [ForeignKey("Funcionario")]
        public int IDFuncionario { get; set; }
        public virtual Funcionario? Funcionario { get; set; }

        [Display(Name = "Cliente")]
        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "O campo Cliente é obrigatório!")]
        public int IDCliente{ get; set; }
        public virtual Cliente? Cliente { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public string? Processo { get; set; }

        [Display(Name = "Nome da Peça")]
        public string? NomePeca { get; set; }

        [Display(Name = "Código Interno")]
        public string? CodigoInterno { get; set; }

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
