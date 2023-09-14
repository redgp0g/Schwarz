using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class Cota
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

		[Display(Name = "Frequência/D")]
		public int FrequenciaMinimaDiaIP{ get; set; }

		[Display(Name = "Frequência/T")]
		public int FrequenciaMinimaTurnoIP { get; set; }

		[Display(Name = "Frequência/S")]
		public int FrequenciaMinimaSetUpIP { get; set; }

		[Display(Name = "Frequência/P")]
		public int FrequenciaMinimaParadaIP { get; set; }

		[Display(Name = "Frequência/F")]
		public int FrequenciaMinimaFinalIP { get; set; }

		[Display(Name = "Frequência/A")]
		public int FrequenciaMinimaAjusteIP { get; set; }

		[Display(Name = "Frequência/H")]
		public int FrequenciaMinimaHoraIP { get; set; }

		[Display(Name = "Amostragem")]
		public int? AmostragemIP { get; set; }

        [Display(Name = "Método IP")]
        public string MetodoIP { get; set; }

        [Display(Name = "Istrumento Alternativo")]
        public string InstrumentoAlternativo { get; set; }

		[Display(Name = "Frequência/D")]
		public int FrequenciaMinimaDiaIA { get; set; }

		[Display(Name = "Frequência/T")]
		public int FrequenciaMinimaTurnoIA { get; set; }

		[Display(Name = "Frequência/S")]
		public int FrequenciaMinimaSetUpIA { get; set; }

		[Display(Name = "Frequência/P")]
		public int FrequenciaMinimaParadaIA { get; set; }

		[Display(Name = "Frequência/F")]
		public int FrequenciaMinimaFinalIA { get; set; }

		[Display(Name = "Frequência/A")]
		public int FrequenciaMinimaAjusteIA { get; set; }

		[Display(Name = "Frequência/H")]
		public int FrequenciaMinimaHoraIA { get; set; }

		[Display(Name = "Amost")]
		public int? AmostragemIA { get; set; }
        [Display(Name = "Método IA")]
        public string MetodoIA { get; set; }

        private readonly SchwarzContext _context;

        public Cota()
		{

		}
		public Cota(SchwarzContext contexto)
		{
			_context = contexto;
		}

		public Cota(int iDPlanoControle)
		{
			IDPlanoControle = iDPlanoControle;
		}

		public Cota(int iDPlanoControle, SchwarzContext context)
		{
			IDPlanoControle = iDPlanoControle;
			_context = context;
		}
	}
}
