using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class Arquivo
	{
		[Key]
		public int IDArquivo { get; set; }
        public string Nome { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[] Conteudo { get; set; }
        public string TipoMIME { get; set; }
        public DateTime DataUpload { get; set; }

        private readonly SchwarzContext _context;
	
        public Arquivo()
		{

		}
		public Arquivo(SchwarzContext contexto)
		{
			_context = contexto;
		}

        public Arquivo(string nome, byte[] conteudo, string tipoMIME, DateTime dataUpload)
        {
            Nome = nome;
            Conteudo = conteudo;
            TipoMIME = tipoMIME;
            DataUpload = dataUpload;
        }
    }
}
