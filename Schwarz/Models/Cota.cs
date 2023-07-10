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
		public virtual PlanoControle? PlanoControle { get; set; }
		public string Item { get; set; }
        public int Ordem { get; set; }

        [Display(Name = "CE")]
        public string? CaracteristicaEspecial { get; set; }

        [Display(Name = "L")]
        public string? Localizacao { get; set; }

        [Display(Name = "Característica Produto")]
        public string? CaracteristicaProduto { get; set; }

        [Display(Name = "Característica Processo")]
        public string? CaracteristicaProcesso { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        public decimal? Nominal { get; set; }

        [Display(Name = "Máx")]
        public decimal? ToleranciaSuperior { get; set; }

        [Display(Name = "Min")]
        public decimal? ToleranciaInferior { get; set; }

		[Display(Name = "IP")]
		public string InstrumentoPrincipal { get; set; }

        [Display(Name = "Código Instrumento")]
        public string? CodigoIP { get; set; }

		[Display(Name = "/D")]
		public int FrequenciaMinimaDiaIP{ get; set; }

		[Display(Name = "/T")]
		public int FrequenciaMinimaTurnoIP { get; set; }

		[Display(Name = "/S")]
		public int FrequenciaMinimaSetUpIP { get; set; }

		[Display(Name = "/P")]
		public int FrequenciaMinimaParadaIP { get; set; }

		[Display(Name = "/F")]
		public int FrequenciaMinimaFinalIP { get; set; }

		[Display(Name = "/A")]
		public int FrequenciaMinimaAjusteIP { get; set; }

		[Display(Name = "/H")]
		public int FrequenciaMinimaHoraIP { get; set; }

		[Display(Name = "Amostragem")]
		public int? AmostragemIP { get; set; }

        [Display(Name = "Método")]
        public string MetodoIP { get; set; }

        [Display(Name = "IA")]
        public string InstrumentoAlternativo { get; set; }

		[Display(Name = "/D")]
		public int FrequenciaMinimaDiaIA { get; set; }

		[Display(Name = "/T")]
		public int FrequenciaMinimaTurnoIA { get; set; }

		[Display(Name = "/S")]
		public int FrequenciaMinimaSetUpIA { get; set; }

		[Display(Name = "/P")]
		public int FrequenciaMinimaParadaIA { get; set; }

		[Display(Name = "/F")]
		public int FrequenciaMinimaFinalIA { get; set; }

		[Display(Name = "/A")]
		public int FrequenciaMinimaAjusteIA { get; set; }

		[Display(Name = "/H")]
		public int FrequenciaMinimaHoraIA { get; set; }

		[Display(Name = "Amost")]
		public int? AmostragemIA { get; set; }
        [Display(Name = "Método")]
        public string MetodoIA { get; set; }


		public Cota()
		{

		}
		public Cota(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

		public Cota(int iDPlanoControle)
		{
			IDPlanoControle = iDPlanoControle;
		}
	}
}
