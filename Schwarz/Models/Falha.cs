using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;

namespace Schwarz.Models
{
	public class Falha
	{
        [Key]
        public int IDFalha { get; set; }
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Display(Name = "Descrição da Falha")]
        public string Descricao { get; set; }
        public string? Setor1 { get; set; }
        public string? Setor2 { get; set; }
        public string? Setor3 { get; set; }

        private readonly SchwarzContext _context;

        public Falha()
		{

		}
		public Falha(SchwarzContext contexto)
		{
			_context = contexto;
		}

	}
}
