using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class Cota : CotaRepository
	{
		[Key]
		public int IDCota { get; set; }
		[ForeignKey("PlanoControle")]
		public int IDPlanoControle { get; set; }
		public PlanoControle PlanoControle { get; set; }
		public string Item { get; set; }
		public string? CaracteristicaEspecial { get; set; }
		public string? Localizacao { get; set; }
		public string? CaracteristicaProduto { get; set; }
		public string? CaracteristicaProcesso { get; set; }
		public string? Descricao { get; set; }
		public decimal ToleranciaSuperior { get; set; }
		public decimal ToleranciaInferior { get; set; }
		public string InstrumentoPrincipal { get; set; }
		public string CodigoIP { get; set; }
		public int FrequenciaMinimaDiaIP{ get; set; }
		public int FrequenciaMinimaTurnoIP { get; set; }
		public int FrequenciaMinimaSetUpIP { get; set; }
		public int FrequenciaMinimaParadaIP { get; set; }
		public int FrequenciaMinimaFinalIP { get; set; }
		public int FrequenciaMinimaAjusteIP { get; set; }
		public int FrequenciaMinimaHoraIP { get; set; }
		public int? AmostragemIP { get; set; }
		public string MetodoIP { get; set; }
		public string InstrumentoAlternativo { get; set; }
		public int FrequenciaMinimaDiaIA { get; set; }
		public int FrequenciaMinimaTurnoIA { get; set; }
		public int FrequenciaMinimaSetUpIA { get; set; }
		public int FrequenciaMinimaParadaIA { get; set; }
		public int FrequenciaMinimaFinalIA { get; set; }
		public int FrequenciaMinimaAjusteIA { get; set; }
		public int FrequenciaMinimaHoraIA { get; set; }
		public int? AmostragemIA { get; set; }
		public string MetodoIA { get; set; }



		public Cota()
		{

		}
		public Cota(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
