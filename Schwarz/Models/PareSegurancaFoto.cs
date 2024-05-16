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
        public string Nome { get; set; }
        public byte[] Conteudo { get; set; }
        public string TipoMIME { get; set; }

		public PareSegurancaFoto()
		{
		}

		public PareSegurancaFoto(int iDPareSeguranca, string nome, byte[] conteudo, string tipoMIME)
		{
			IDPareSeguranca = iDPareSeguranca;
			Nome = nome;
			Conteudo = conteudo;
			TipoMIME = tipoMIME;
		}
	}
}
