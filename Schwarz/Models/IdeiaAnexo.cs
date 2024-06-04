using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class IdeiaAnexo
	{
		[Key]
		public int IDIdeiaAnexo { get; set; }
        public string Nome { get; set; } = string.Empty;
        [Column(TypeName = "varbinary(max)")]
        public byte[] Anexo { get; set; } = new byte[0];
        public string TipoMIME { get; set; } = string.Empty;

		[ForeignKey("Ideia")]
        public int IDIdeia { get; set; }
        public virtual Ideia? Ideia { get; set; }
	
        public IdeiaAnexo(string nome,byte[] anexo, string tipoMIME, int iDIdeia)
        {
            Nome = nome;
            Anexo = anexo;
            TipoMIME = tipoMIME;
            IDIdeia = iDIdeia;
        }
    }
}
