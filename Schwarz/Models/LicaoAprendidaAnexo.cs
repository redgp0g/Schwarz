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
        public virtual LicaoAprendida LicaoAprendida { get; set; }
        public string Nome { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[] Conteudo{ get; set; }
        public string TipoMIME { get; set; }

        private readonly SchwarzContext _context;
	
        public LicaoAprendidaAnexo()
		{

		}

        public LicaoAprendidaAnexo(int iDLicaoAprendida, string nome, byte[] conteudo, string tipoMIME)
        {
            IDLicaoAprendida = iDLicaoAprendida;
            Nome = nome;
            Conteudo = conteudo;
            TipoMIME = tipoMIME;
        }
    }
}
