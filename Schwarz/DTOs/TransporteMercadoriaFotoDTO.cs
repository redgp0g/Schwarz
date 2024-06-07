namespace Schwarz.DTOs
{
    public class TransporteMercadoriaFotoDto
    {
        public int IDTransporteMercadoriaFoto { get; set; }
        public int IDTransporteMercadoria { get; set; }
        public string Nome { get; set; }
        public string ConteudoBase64 { get; set; }
        public string TipoMIME { get; set; }
    }
}
