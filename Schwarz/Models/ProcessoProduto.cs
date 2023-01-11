using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class ProcessoProduto : ProcessoProdutoRepository
    {
        [Key]
        public int IDProcessoProduto { get; set; }
        [ForeignKey("Processo")]
        public int IDProcesso { get; set; }
        public virtual Processo Processo { get; set; }
        [ForeignKey("Produto")]
        public int IDProduto { get; set; }
        public virtual Produto Produto { get; set; }

		public ProcessoProduto()
		{

		}
		public ProcessoProduto(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
