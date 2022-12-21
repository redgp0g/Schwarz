using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;
using System.Security.Permissions;
using Schwarz.Areas.Identity.Data;

namespace Schwarz.Models
{
    public class CadastroOleo
    {
        [Key]
        public int IDCadastroOleo { get; set; }
        [ForeignKey("User")]
        public string Usuario { get; set; }
        public SchwarzUser? User { get; set; }

        [ForeignKey("Maquina")]
        [Required(ErrorMessage = "Selecione uma máquina")]
        public int IDMaquina { get; set; }
        public virtual Maquina? Maquina { get; set; }

        [Display(Name = "Tipo do Óleo")]
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public double Litros { get; set; }

        [Display(Name = "Diário de Bordo")]
        public string? DiarioBordo { get; set; }
        private readonly SchwarzContext _context;

        public CadastroOleo()
        {

        }
        public CadastroOleo(SchwarzContext contexto)
        {
            _context= contexto;
        }
        public List<Maquina> GetMaquinas()
        {
            return _context.Maquina.ToList();
        }
    }
}
