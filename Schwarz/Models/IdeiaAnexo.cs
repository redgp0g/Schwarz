using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class IdeiaAnexo
	{
		[Key]
		public int IDIdeiaAnexo { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[]? Anexo { get; set; }
        public string Caminho { get; set; }
        public string TipoMIME { get; set; }
        public long Tamanho{ get; set; }
        public DateTime DataUpload{ get; set; }

		[ForeignKey("Ideia")]
        public int IDIdeia { get; set; }
        public virtual Ideia Ideia { get; set; }

		private readonly SchwarzContext _context;
	
        public IdeiaAnexo()
		{

		}
		public IdeiaAnexo(SchwarzContext contexto)
		{
			_context = contexto;
		}

	}
}
