using Microsoft.EntityFrameworkCore;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;

namespace Schwarz.Models
{
	public class Produto : ProdutoRepository
	{
		[Key]
		public int IDProduto { get; set; }

		[Required(ErrorMessage = "Digite o nome do Produto")]
		[Display(Name = "Nome do Produto")]
		public string Nome { get; set; }

		[Display(Name = "Cliente")]
		[Required(ErrorMessage = "Selecione oCliente")]
		[ForeignKey("Cliente")]
		public int IDCliente { get; set; }
		public virtual Cliente Cliente { get; set; }

		[Required(ErrorMessage = "Digite o código do Cliente")]
		[Display(Name = "Código Cliente")]
		public int CodigoCliente { get; set; }
		public virtual ICollection<Desenho>? Desenhos { get; set; }
		public virtual ICollection<Processo>? Processos { get; set; }
		public Produto()
		{

		}
		public Produto(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
