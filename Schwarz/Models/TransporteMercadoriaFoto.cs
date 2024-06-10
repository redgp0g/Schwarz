using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class TransporteMercadoriaFoto
    {
		[Key]
		public int IDTransporteMercadoriaFoto { get; set; }

		[ForeignKey("TransporteMercadoria")]
        public int IDTransporteMercadoria { get; set; }
        public virtual TransporteMercadoria? TransporteMercadoria { get; set; }
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varbinary(max)")]
        public byte[] Conteudo{ get; set; } = new byte[0];
        public string TipoMIME { get; set; } = string.Empty;

        public TransporteMercadoriaFoto()
        {
        }

        public TransporteMercadoriaFoto(int iDTransporteMercadoria, string nome, byte[] conteudo, string tipoMIME)
        {
            IDTransporteMercadoria = iDTransporteMercadoria;
            Nome = nome;
            Conteudo = conteudo;
            TipoMIME = tipoMIME;
        }
    }
}
