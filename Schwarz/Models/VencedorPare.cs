using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
	public class VencedorPare
	{

        [Key]
        public int IDVencedorPare { get; set; }

        [DisplayName("Pontuação Total")]
        public int PontuacaoTotal { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
