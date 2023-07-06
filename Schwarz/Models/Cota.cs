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

        [Display(Name = "Característica Especial")]
        public string? CaracteristicaEspecial { get; set; }

        [Display(Name = "Localização")]
        public string? Localizacao { get; set; }

        [Display(Name = "Característica Produto")]
        public string? CaracteristicaProduto { get; set; }

        [Display(Name = "Característica Processo")]
        public string? CaracteristicaProcesso { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        public decimal? Nominal { get; set; }

        [Display(Name = "Tolerância Superior")]
        public decimal? ToleranciaSuperior { get; set; }

        [Display(Name = "Tolerância Inferior")]
        public decimal? ToleranciaInferior { get; set; }

		[Display(Name = "Instrumento Principal")]
		public string InstrumentoPrincipal { get; set; }

        [Display(Name = "Código Instrumento")]
        public string? CodigoIP { get; set; }
		public int FrequenciaMinimaDiaIP{ get; set; }
		public int FrequenciaMinimaTurnoIP { get; set; }
		public int FrequenciaMinimaSetUpIP { get; set; }
		public int FrequenciaMinimaParadaIP { get; set; }
		public int FrequenciaMinimaFinalIP { get; set; }
		public int FrequenciaMinimaAjusteIP { get; set; }
		public int FrequenciaMinimaHoraIP { get; set; }
		public int? AmostragemIP { get; set; }

        [Display(Name = "Método Instrumento Principal")]
        public string MetodoIP { get; set; }

        [Display(Name = "Instrumento Alternativo")]
        public string InstrumentoAlternativo { get; set; }
		public int FrequenciaMinimaDiaIA { get; set; }
		public int FrequenciaMinimaTurnoIA { get; set; }
		public int FrequenciaMinimaSetUpIA { get; set; }
		public int FrequenciaMinimaParadaIA { get; set; }
		public int FrequenciaMinimaFinalIA { get; set; }
		public int FrequenciaMinimaAjusteIA { get; set; }
		public int FrequenciaMinimaHoraIA { get; set; }
		public int? AmostragemIA { get; set; }

        [Display(Name = "Método Instrumento Alternativo")]
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
