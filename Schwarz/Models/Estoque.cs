using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class Estoque
	{
		[Key]
		public int IDEstoque{ get; set; }

		[ForeignKey("SchwarzUser")]
		public string IdAspNetUser{ get; set; }
		public virtual SchwarzUser? SchwarzUser{ get; set; }
        public string Setor { get; set; }
        public string Urgencia { get; set; }
		public DateTime Data { get; set; }
        public int Peca { get; set; }
        public int Quantidade { get; set; }
        public bool Entregue { get; set; }

        private readonly SchwarzContext _context;
			
		public Estoque()
		{

		}
		public Estoque(SchwarzContext contexto)
		{
			_context = contexto;
		}
	}
}
