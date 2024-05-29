using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PareSegurancaFoto
	{
        [Key]
        public int IDPareSegurancaFoto { get; set; }

		[Required]
		[ForeignKey("PareSeguranca")]
        public int IDPareSeguranca { get; set; }
        public virtual PareSeguranca? PareSeguranca { get; set; }
		public string Nome { get; set; } = string.Empty;
		public byte[] Conteudo { get; set; } = new byte[0];
        public string TipoMIME { get; set; } = string.Empty;

		public PareSegurancaFoto(int iDPareSeguranca, string nome, byte[] conteudo, string tipoMIME)
		{
			IDPareSeguranca = iDPareSeguranca;
			Nome = nome;
			Conteudo = conteudo;
			TipoMIME = tipoMIME;
		}
	}
}
