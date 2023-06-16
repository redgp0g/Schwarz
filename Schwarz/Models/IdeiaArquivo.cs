using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class IdeiaArquivo : IdeiaArquivoRepository
	{
		[Key]
		public int IDIdeiaArquivo { get; set; }
		[ForeignKey("IDArquivo")]
		public virtual Arquivo Arquivo { get; set; }
        public int IDArquivo { get; set; }
        [ForeignKey("IDIdeia")]
        public virtual Ideia Ideia { get; set; }
        public int IDIdeia { get; set; }

        public IdeiaArquivo()
		{

		}
		public IdeiaArquivo(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
