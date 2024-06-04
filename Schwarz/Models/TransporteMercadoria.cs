﻿using Newtonsoft.Json.Serialization;
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

        [ForeignKey("Cliente")]
        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O Cliente é obrigatório!")]
        public int IDCliente { get; set; }
        public virtual Cliente? Cliente { get; set; }

        [Required]
        [ForeignKey("Funcionario")]
        public int IDFuncionario { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        [DisplayName("Nota Fiscal")]
        [Required(ErrorMessage = "A Nota Fiscal é obrigatória!")]
        public string NotaFiscal { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Volume é obrigatório!")]
        public int Volume { get; set; }

        [Required(ErrorMessage = "O Tipo de Volume é obrigatório!")]
        public string TipoVolume { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Transportadora é obrigatória!")]
        public string Transportadora { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Placa é obrigatória!")]
        public string Placa { get; set; } = string.Empty;

        [NotMapped]
        [DisplayName("Foto da Placa")]
        [Required(ErrorMessage = "A Foto da Placa é obrigatório!")]
        public IFormFile fileFotoPlaca { get; set; } = null!;

        [NotMapped]
        [DisplayName("Foto do Lacre")]
        public IFormFile? fileFotoLacre { get; set; }

        [NotMapped]
        [DisplayName("Fotos antes do carregamento")]
        [Required(ErrorMessage = "A Foto é obrigatória!")]
        public List<IFormFile>? filesFotoAntes { get; set; }

        [NotMapped]
        [DisplayName("Fotos depois do carregamento")]
        [Required(ErrorMessage = "A Foto é obrigatória!")]
        public List<IFormFile>? filesFotoDepois { get; set; }
        
        [NotMapped]
        [DisplayName("Foto da Nota Fiscal")]
        [Required(ErrorMessage = "A Foto da Nota Fiscal é obrigatória!")]
        public List<IFormFile>? filesFotoNotaFiscal { get; set; }

        [NotMapped]
        [DisplayName("Foto do Romaneio")]
        [Required(ErrorMessage = "A Foto do Romaneio é obrigatória!")]
        public IFormFile fileFotoRomaneio { get; set; } = null!;

        public virtual ICollection<TransporteMercadoriaFoto>? Fotos { get; set; }
    }
}
