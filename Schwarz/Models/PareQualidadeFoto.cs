using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PareQualidadeFoto
	{
        [Key]
        public int IDPareQualidadeFoto { get; set; }

		[Required]
		[ForeignKey("PareQualidade")]
		public int IDPareQualidade { get; set; }
		public virtual PareQualidade? PareQualidade { get; set; }
		public string Nome { get; set; }
        public byte[] Conteudo { get; set; }
        public string TipoMIME { get; set; }

		public PareQualidadeFoto()
		{
		}

		public PareQualidadeFoto(int iDPareQualidade, string nome, byte[] conteudo, string tipoMIME)
		{
			IDPareQualidade = iDPareQualidade;
			Nome = nome;
			Conteudo = conteudo;
			TipoMIME = tipoMIME;
		}
	}
}
