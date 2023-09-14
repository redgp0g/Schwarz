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
		public string Identificacao{ get; set; }
		public int Codigo { get; set; }
		public string Descricao { get; set; }

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
