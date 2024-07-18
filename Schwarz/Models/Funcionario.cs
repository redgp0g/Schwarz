using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class Funcionario
    {
        [Key]
        public int IDFuncionario { get; set; }
        public int? Matricula { get; set; }

        [Required(ErrorMessage = "O Nome do Funcionário é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Setor do Funcionário é obrigatório")]
        public string Setor { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "O Turno do Funcionário é obrigatório")]
        public string Turno { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [ForeignKey("FuncionarioLider")]
        [Required(ErrorMessage = "O Líder do Funcionário é obrigatório")]
        public int IDLider { get; set; }
        public virtual Funcionario? FuncionarioLider { get; set; }

        [Required(ErrorMessage = "O Cargo do Funcionário é obrigatório")]
        public string Cargo { get; set; }
        public string? Ramal { get; set; }
        public byte[]? Foto { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public int? NumeroCentroCusto { get; set; }
        public string? CPF { get; set; }
        public virtual SchwarzUser? User { get; set; }
        public virtual ICollection<IdeiaEquipe>? IdeiaEquipe { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "A imagem do Funcionário é obrigatória")]
        [Display(Name = "Foto do Funcionário")]
        public IFormFile? FileFoto { get; set; }

        [NotMapped]
        public string PrimeiroUltimoNome
        {
            get
            {
                string[] nomes = Nome.Split(' ');
                if (nomes.Length < 2)
                    return Nome;

                return nomes[0] + " " + nomes[nomes.Length - 1];
            }
        }
    }
}