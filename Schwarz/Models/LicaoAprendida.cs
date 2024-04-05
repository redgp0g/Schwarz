using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class LicaoAprendida
    {

        [Key]
        public int IDLicaoAprendida { get; set; }

        [Required(ErrorMessage = "O campo Planejado é obrigatório!")]
        public string Planejado { get; set; }

        [Required(ErrorMessage = "O campo Realizado é obrigatório!")]
        public string Realizado { get; set; }

        [Required(ErrorMessage = "O campo Motivo é obrigatório!")]
        public string Motivo { get; set; }

        [ForeignKey("Funcionario")]
        public int IDFuncionario { get; set; }
        public virtual Funcionario? Funcionario { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Processo é obrigatório!")]
        public string Processo { get; set; }

        [Display(Name = "Nome da Peça")]
        [Required(ErrorMessage = "O nome da peça é obrigatória!")]
        public string NomePeca { get; set; }

        [Display(Name = "Código Interno")]
        [Required(ErrorMessage = "O Codigo Interno é obrigatório!")]
        [Range(100000000,999999999,ErrorMessage = "O Código interno está errado!")]
        public int CodigoInterno { get; set; }

        [Display(Name = "Lição Aprendida")]
        [Required(ErrorMessage = "A Lição Aprendida é obrigatória!")]
        public string Descricao { get; set; }

        [Display(Name = "Positivo/Negativo")]
        public bool Positivo { get; set; }

        public virtual ICollection<LicaoAprendidaArquivo>? LicaoAprendidaArquivos { get; set; }

        [NotMapped]
        public List<IFormFile>? Arquivos { get; set; }

        public LicaoAprendida() { }
    }
}
