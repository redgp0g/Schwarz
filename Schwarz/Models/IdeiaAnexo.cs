using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class IdeiaAnexo
	{
		[Key]
		public int IDIdeiaAnexo { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[] Anexo { get; set; }
        public string TipoMIME { get; set; }

		[ForeignKey("Ideia")]
        public int IDIdeia { get; set; }
        public virtual Ideia? Ideia { get; set; }

		private readonly SchwarzContext _context;
	
        public IdeiaAnexo()
		{

		}
		public IdeiaAnexo(SchwarzContext contexto)
		{
			_context = contexto;
		}

        public IdeiaAnexo(string nome,byte[] anexo, string tipoMIME, int iDIdeia)
        {
            Nome = nome;
            Anexo = anexo;
            TipoMIME = tipoMIME;
            IDIdeia = iDIdeia;
        }
    }
}
