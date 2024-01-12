using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class Cota
	{
		[Key]
		public int IDCota { get; set; }

        [Display(Name = "Plano de Controle")]
        [ForeignKey("PlanoControle")]
		public int IDPlanoControle { get; set; }

        [Display(Name = "Plano de Controle")]
        public virtual PlanoControle? PlanoControle { get; set; }
        public int Ordem { get; set; }
        public string Item { get; set; }

        [Display(Name = "Característica")]
        public string Caracteristica{ get; set; }

        [Display(Name = "Tipo da Característica")]
        public string TipoCaracteristica { get; set; }

        [Display(Name = "Característica Especial")]
        public string? CaracteristicaEspecial { get; set; }

        [Display(Name = "Localização")]
        public string? Localizacao { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; } 
        public decimal? Nominal { get; set; }

        [Display(Name = "Tolerância Mínima")]
        public decimal? ToleranciaMinima { get; set; }

        [Display(Name = "Tolerância Máxima")]
        public decimal? ToleranciaMaxima { get; set; }

        [Display(Name = "Unidade de Medida")]
        public string? UnidadeMedida { get; set; }

		[Display(Name = "Instrumento Principal")]
		public string InstrumentoPrincipal { get; set; }

        [Display(Name = "100%")]
        public bool AmostragemIP { get; set; }

        [Display(Name = "Frequência/D")]
		public int FrequenciaDiaIP{ get; set; }

		[Display(Name = "Frequência/T")]
		public int FrequenciaTurnoIP { get; set; }

		[Display(Name = "Frequência/S")]
		public int FrequenciaSetUpIP { get; set; }

		[Display(Name = "Frequência/P")]
		public int FrequenciaParadaIP { get; set; }

		[Display(Name = "Frequência/F")]
		public int FrequenciaFinalIP { get; set; }

		[Display(Name = "Frequência/A")]
		public int FrequenciaAjusteIP { get; set; }

		[Display(Name = "Frequência/H")]
		public int FrequenciaHoraIP { get; set; }

        [Display(Name = "MT")]
        public bool MonitoramentoIP{ get; set; }

        [Display(Name = "RI")]
        public bool RegistroInspecaoIP{ get; set; }

        [Display(Name = "CPE")]
        public bool ControleEstatisticoProcessoIP{ get; set; }

        [Display(Name = "Istrumento Secundário")]
        public string InstrumentoSecundario { get; set; }

        [Display(Name = "100%")]
        public bool AmostragemIS { get; set; }

        [Display(Name = "Frequência/D")]
		public int FrequenciaDiaIS { get; set; }

		[Display(Name = "Frequência/T")]
		public int FrequenciaTurnoIS { get; set; }

		[Display(Name = "Frequência/S")]
		public int FrequenciaSetUpIS { get; set; }

		[Display(Name = "Frequência/P")]
		public int FrequenciaParadaIS { get; set; }

		[Display(Name = "Frequência/F")]
		public int FrequenciaFinalIS { get; set; }

		[Display(Name = "Frequência/A")]
		public int FrequenciaAjusteIS { get; set; }

		[Display(Name = "Frequência/H")]
		public int FrequenciaHoraIS { get; set; }

        [Display(Name = "MT")]
        public bool MonitoramentoIS { get; set; }

        [Display(Name = "RI")]
        public bool RegistroInspecaoIS { get; set; }

        [Display(Name = "CPE")]
        public bool ControleEstatisticoProcessoIS { get; set; }

        [Display(Name = "Situação")]
        public string Situacao { get; set; }
		public bool Visual {  get; set; }

        private readonly SchwarzContext _context;

        public Cota()
		{

		}
		public Cota(SchwarzContext contexto)
		{
			_context = contexto;
		}
	}
}
