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
        public virtual TransporteMercadoria TransporteMercadoria { get; set; }
        public string Nome { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[] Conteudo{ get; set; }
        public string TipoMIME { get; set; }

        private readonly SchwarzContext _context;
	
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
