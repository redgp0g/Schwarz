using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class LicaoAprendidaAnexo
    {
		[Key]
		public int IDLicaoAprendidaAnexo { get; set; }

		[ForeignKey("LicaoAprendida")]
        public int IDLicaoAprendida{ get; set; }
        public virtual LicaoAprendida LicaoAprendida { get; set; } = new LicaoAprendida();
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varbinary(max)")]
        public byte[] Conteudo{ get; set; } = new byte[0];
        public string TipoMIME { get; set; } = string.Empty;

        public LicaoAprendidaAnexo(int iDLicaoAprendida, string nome, byte[] conteudo, string tipoMIME)
        {
            IDLicaoAprendida = iDLicaoAprendida;
            Nome = nome;
            Conteudo = conteudo;
            TipoMIME = tipoMIME;
        }
    }
}
