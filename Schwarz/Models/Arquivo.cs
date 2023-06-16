using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
	public class Arquivo : ArquivoRepository
	{
		[Key]
		public int IDArquivo { get; set; }
		public string Nome { get; set; }
        public string Caminho { get; set; }
        public string TipoMIME { get; set; }
        public long Tamanho{ get; set; }
        public DateTime DataUpload{ get; set; }

        public Arquivo()
		{

		}
		public Arquivo(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
