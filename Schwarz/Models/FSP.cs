using Microsoft.EntityFrameworkCore;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;

namespace Schwarz.Models
{
	public class FSP : FSPRepository
	{
		[Key]
		public int IDFSP	 { get; set; }
		
		public DateTime DataAbertura { get; set; }
		public DateTime? DataFechamento { get; set; }

		[ForeignKey("Processo")]
		public int IDProcesso { get; set; }
		public virtual Processo Processo { get; set; }
		public string Origem { get; set; }

		[ForeignKey("Falha")]
		public int IDFalha { get; set; }
		public virtual Falha Falha { get; set; }
		public string? MaodeObra { get; set; }
        public string? Maquina { get; set; }
        public string? Medida { get; set; }
        public string? Material { get; set; }
        public string? MeioAmbiente { get; set; }
        public string? Metodo{ get; set; }
        public string? PorqueFalhou1 { get; set; }
        public string? PorqueFalhou2 { get; set; }
        public string? PorqueFalhou3 { get; set; }
        public string? PorqueFalhou4 { get; set; }
        public string? PorqueFalhou5 { get; set; }
        public string? CausaRaizFalha{ get; set; }
        public string? PorquePassou1 { get; set; }
        public string? PorquePassou2 { get; set; }
        public string? PorquePassou3 { get; set; }
        public string? PorquePassou4 { get; set; }
        public string? PorquePassou5 { get; set; }
        public string? CausaRaizPassou { get; set; }
        public bool AtualizarFMEA { get; set; }
        public string QualFMEA { get; set; }

        [ForeignKey("FuncionarioFMEA")]
        public int IDFuncionarioFMEA { get; set; }
        public virtual Funcionario FuncionarioFMEA { get; set; }
        public DateTime PrazoFMEA{ get; set; }
        public bool RealizadoFMEA{ get; set; }

        public bool AtualizarInstrucao { get; set; }
        public string QualInstrucao { get; set; }

        [ForeignKey("FuncionarioInstrucao")]
        public int IDFuncionarioInstrucao { get; set; }
        public virtual Funcionario FuncionarioInstrucao { get; set; }
        public DateTime PrazoInstrucao { get; set; }
        public bool RealizadoInstrucao { get; set; }

        public bool AtualizarPlanoControle { get; set; }
        public string QualPlanoControle { get; set; }

        [ForeignKey("FuncionarioFMEA")]
        public int IDFuncionarioPlanoControle { get; set; }
        public virtual Funcionario FuncionarioPlanoControle { get; set; }
        public DateTime PrazoPlanoControle { get; set; }
        public bool RealizadoPlanoControle { get; set; }

        public bool UtilizarPokaYoke { get; set; }
        public string QualPokaYoke { get; set; }

        [ForeignKey("FuncionarioPokaYoke")]
        public int IDFuncionarioPokaYoke { get; set; }
        public virtual Funcionario FuncionarioPokaYoke { get; set; }
        public DateTime PrazoPokaYoke { get; set; }
        public bool RealizadoPokaYoke { get; set; }

        public bool AplicarTreinamento { get; set; }
        public string QualTreinamento { get; set; }

        [ForeignKey("FuncionarioTreinamento")]
        public int IDFuncionarioTreinamento { get; set; }
        public virtual Funcionario FuncionarioTreinamento { get; set; }
        public DateTime PrazoTreinamento { get; set; }
        public bool RealizadoTreinamento { get; set; }

        public bool EmitirAlertaQualidade { get; set; }
        public string QualAlertaQualidade { get; set; }

        [ForeignKey("FuncionarioAlertaQualidade")]
        public int IDFuncionarioAlertaQualidade { get; set; }
        public virtual Funcionario FuncionarioQualidade { get; set; }
        public DateTime PrazolAlertaQualidade { get; set; }
        public bool RealizadoAlertaQualidade { get; set; }

        [ForeignKey("FuncionarioVerificacao")]
        public int IDFuncionarioVerificacao{ get; set; }
        public virtual Funcionario FuncionarioVerificacao { get; set; }
        public DateTime DataVerificacao { get; set; }
        public string IndicadorVerificacao { get; set; }
        public bool EficazVerificacao { get; set; }
        public string MetodologiaVerificacao { get; set; }

        [ForeignKey("NovaFSP")]
        public int IDNovaFSP { get; set; }
        public virtual FSP NovaFSP { get; set; }
        [ForeignKey("FuncionarioNovaFSP")]
        public int? IDFuncionarioNovaFSP { get; set; }
        public virtual Funcionario FuncionarioNovaFSP { get; set; }


        public FSP()
		{

		}
		public FSP(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
