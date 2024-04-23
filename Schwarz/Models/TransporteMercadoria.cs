using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class TransporteMercadoria
    {

        [Key]
        [DisplayName("ID")]
        public int IDTransporteMercadoria { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        [DisplayName("Cliente")]
        public int IDCliente { get; set; }
        public virtual Cliente? Cliente { get; set; }

        [Required]
        [ForeignKey("Funcionario")]
        public int IDFuncionario { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        [DisplayName("Nota Fiscal")]
        [Required(ErrorMessage = "A Nota Fiscal é obrigatória!")]
        public int NotaFiscal { get; set; }

        [Required(ErrorMessage = "O Volume é obrigatório!")]
        public int Volume { get; set; }

        [Required(ErrorMessage = "O tipo de volume é obrigatório!")]
        public string TipoVolume { get; set; }

        [Required(ErrorMessage = "A transportadora é obrigatória!")]
        public string Transportadora { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória!")]
        public string Placa { get; set; }

        [NotMapped]
        [DisplayName("Foto da Placa")]
        [Required(ErrorMessage = "A foto da placa é obrigatório!")]
        public IFormFile fileFotoPlaca { get; set; }

        [NotMapped]
        [DisplayName("Foto do Lacre")]
        [Required(ErrorMessage = "A foto do lacre é obrigatório!")]
        public IFormFile fileFotoLacre { get; set; }

        [NotMapped]
        [DisplayName("Fotos antes do carregamento")]
        [Required(ErrorMessage = "As fotos são obrigatórias!")]
        public List<IFormFile> filesFotosAntes { get; set; }

        [NotMapped]
        [DisplayName("Fotos depois do carregamento")]
        [Required(ErrorMessage = "As fotos são obrigatórias!")]
        public List<IFormFile> filesFotosDepois { get; set; }

        public virtual ICollection<TransporteMercadoriaFoto> Fotos { get; set; }

        public TransporteMercadoria()
        {

        }
    }
}
