using Microsoft.EntityFrameworkCore;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;

namespace Schwarz.Models
{
	public class Processo : ProcessoRepository
	{
		[Key]
		public int IDProcesso { get; set; }

		[Display(Name = "Código Interno")]
		public int CodigoInterno { get; set; }

		[ForeignKey("Produto")]
		public int IDProduto { get; set; }
		public virtual Produto? Produto { get; set; }

		[ForeignKey("Operacao")]
		public int IDOperacao { get; set; }
		public virtual Operacao? Operacao { get; set; }
		public virtual ICollection<Desenho>? Desenhos { get; set; }
		public Processo()
		{

		}
		public Processo(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
