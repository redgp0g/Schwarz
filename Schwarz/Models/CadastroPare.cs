using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class CadastroPare
    {

        [Key]
        public int IDCadastroPare { get; set; }

        [Display(Name = "Funcionário")]
        [ForeignKey("Funcionario")]
        [Required(ErrorMessage = "Selecione o Funcionário!")]
        public int IDFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Descreva onde ocorreu o problema!")]
        public string Local { get; set; }

        [Display(Name = "Código do Item")]
        [MinLength(9, ErrorMessage = "O código deve ter 9 digítos!")]
        public string? CodigoItem { get; set; }

        [Display(Name = "Quantidade Bloqueada")]
        public int? QuantidadeBloqueada { get; set; }

        [Required(ErrorMessage = "Selecione o Risco")]
        public string Risco { get; set; }
        public string Status { get; set; }

        [Display(Name = "Desvio")]
        public string? Desvio { get; set; }

        [ForeignKey("Falha")]
        [Display(Name = "Falha")]
        public int? IDFalha { get; set; }
        public virtual Falha? Falha { get; set; }

        [Display(Name = "N° da FSP")]
        public int? NumeroFSP { get; set; }

        [ForeignKey("FuncionarioFacilitador")]
        [Display(Name = "Facilitador")]
        public int? IDFuncionarioFacilitador { get; set; }
        public virtual Funcionario? FuncionarioFacilitador { get; set; }

        [Display(Name = "Pontuação")]
        public int? Pontuacao { get; set; }

        [Display(Name = "Válido para o Programa?")]
        public string ValidaPontuacao { get; set; }

        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        [NotMapped]
        public string DataFormatada => Data.ToString("dd/MM/yyyy");

        private readonly SchwarzContext _context;
        public CadastroPare(SchwarzContext contexto)
        {
            _context = contexto;
        }
        public CadastroPare()
        {
        }
    }
}
