using Microsoft.EntityFrameworkCore;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;

namespace Schwarz.Models
{
	public class Desenho : DesenhoRepository
	{
		[Key]
		public int IDDesenho { get; set; }
		[ForeignKey("Processo")]
		public int? IDProcesso { get; set; }
		public virtual Processo? Processo { get; set; }
		[ForeignKey("Produto")]
		public int? IDProduto { get; set; }
		public virtual Produto? Produto { get; set; }

		[Display(Name = "Observações")]
		public string? Observacoes { get; set; }
		public DateTime Data { get; set; }
		//A data deveria ser DateOnly, mas fica o valor padrão(01/01/0001) e não muda

		[Display(Name = "Revisão")]
		public int Revisao { get; set; }

		[Display(Name = "Descrição da Revisão")]
		public string DescricaoRevisao { get; set; }

		[ForeignKey("FuncionarioDesenhador")]
		public int? IDFuncionarioDesenhador { get; set; }
		public virtual Funcionario? FuncionarioDesenhador { get; set; }

		[ForeignKey("FuncionarioAprovador")]
		public int? IDFuncionarioAprovador { get; set; }
		public virtual Funcionario? FuncionarioAprovador { get; set; }
		public virtual ICollection<DesenhoBoleto>? DesenhoBoletos { get; set; }

		public Desenho()
		{

		}
		public Desenho(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
