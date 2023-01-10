using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class DesenhoBoleto : DesenhoBoletoRepository
	{
		[Key]
		public int IDDesenhoBoleto { get; set; }
		[ForeignKey("Desenho")]
		public int IDDesenho { get; set; }
		public virtual Desenho? Desenho { get; set; }
		[ForeignKey("Boleto")]
		public int IDBoleto { get; set; }
		public virtual Boleto? Boleto { get; set; }
		public DesenhoBoleto()
		{

		}
		public DesenhoBoleto(int iDDesenho, SchwarzContext contexto) : base(contexto)
		{
			IDDesenho = iDDesenho;
			_context = contexto;
		}
		public DesenhoBoleto(SchwarzContext contexto)
		{
			_context = contexto;
		}
	}
}
