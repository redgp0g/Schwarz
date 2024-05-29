using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class RegistroCotas
    {
        [Key]
        public int IDRegistroCotas { get; set; }
        public string NomeCota { get; set; } = string.Empty;
        public int NumeroPeca { get; set; }
        public string ValorEncontrado { get; set; } = string.Empty;
        public bool InstrumentoAlternativo { get; set; }
        public string IndicadorMinMax { get; set; } = string.Empty;
        public int OrdemCota { get; set; }

        [ForeignKey("Registro")]
        public int CodigoRegistro { get; set; }
        public virtual Registro Registro { get; set; } = new Registro();
    }
}
