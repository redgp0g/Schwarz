using Microsoft.EntityFrameworkCore;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;
using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;

namespace Schwarz.Models
{
	[Index(nameof(Numero),IsUnique = true)]//Not Working
	public class FSP : FSPRepository
	{
		[Key]
		public int IDFSP { get; set; }
		
		[Display(Name = "Documento N°")]
		public int Numero { get; set; }
		
		[Display(Name = "Data de Abertura")]
        public DateTime DataAbertura { get; set; }
        [Display(Name = "Data de Fechamento")]
        public DateTime? DataFechamento { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Produto { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Digite o código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Digite a origem")]
        public string Origem { get; set; }

		[ForeignKey("Falha")]
        [Display(Name = "Descrição Não Conformidade")]
        [Required(ErrorMessage = "Selecione a não conformidade")]
        public int IDFalha { get; set; }
		public virtual Falha? Falha { get; set; }

        [Display(Name = "Mão de Obra")]
		public string? MaodeObra { get; set; }

        [Display(Name = "Máquina")]
        public string? Maquina { get; set; }

        [Display(Name = "Medição")]
        public string? Medicao { get; set; }

        [Display(Name = "Matéria Prima")]
        public string? Material { get; set; }

        [Display(Name = "Meio Ambiente")]
        public string? MeioAmbiente { get; set; }

        [Display(Name = "Método")]
        public string? Metodo{ get; set; }

        [Display(Name = "Por que Falhou?")]
        public string? PorqueFalhou1 { get; set; }

        [Display(Name = "Por que Falhou?")]
        public string? PorqueFalhou2 { get; set; }

        [Display(Name = "Por que Falhou?")]
        public string? PorqueFalhou3 { get; set; }

        [Display(Name = "Por que Falhou?")]
        public string? PorqueFalhou4 { get; set; }

        [Display(Name = "Por que Falhou?")]
        public string? PorqueFalhou5 { get; set; }

        [Display(Name = "Causa Raiz")]
        public string? CausaRaizFalha{ get; set; }

        [Display(Name = "Por que Passou?")]
        public string? PorquePassou1 { get; set; }

        [Display(Name = "Por que Passou?")]
        public string? PorquePassou2 { get; set; }

        [Display(Name = "Por que Passou?")]
        public string? PorquePassou3 { get; set; }

        [Display(Name = "Por que Passou?")]
        public string? PorquePassou4 { get; set; }

        [Display(Name = "Por que Passou?")]
        public string? PorquePassou5 { get; set; }

        [Display(Name = "Causa Raiz")]
        public string? CausaRaizPassou { get; set; }



        [Display(Name = "Atualizar FMEA?")]
        [Required(ErrorMessage = "Selecione a opção")]
        public bool AtualizarFMEA { get; set; }

        [Display(Name = "Qual?")]
        public string? QualFMEA { get; set; }

        [ForeignKey("SchwarzUserFMEA")]
        [Display(Name = "Responsável")]
        public string? IDSchwarzUserFMEA { get; set; }
        public virtual SchwarzUser? SchwarzUserFMEA { get; set; }

        [Display(Name = "Prazo")]
        public DateTime? PrazoFMEA{ get; set; }

        [Display(Name = "Realizado?")]
        public bool? RealizadoFMEA{ get; set; }



        [Display(Name = "Alterar Instrução de Trabalho?")]
        [Required(ErrorMessage = "Selecione a opção")]
        public bool AtualizarInstrucao { get; set; }

        [Display(Name = "Qual?")]
        public string? QualInstrucao { get; set; }

        [ForeignKey("SchwarzUserInstrucao")]
        [Display(Name = "Responsável")]
        public string? IDSchwarzUserInstrucao { get; set; }
        public virtual SchwarzUser? SchwarzUserInstrucao { get; set; }

        [Display(Name = "Prazo")]
        public DateTime? PrazoInstrucao { get; set; }

        [Display(Name = "Realizado?")]
        public bool? RealizadoInstrucao { get; set; }



        [Display(Name = "Alterar Plano de Controle?")]
        [Required(ErrorMessage = "Selecione a opção")]
        public bool AtualizarPlanoControle { get; set; }

        [Display(Name = "Qual?")]
        public string? QualPlanoControle { get; set; }

        [ForeignKey("SchwarzUserPlanoControle")]
        [Display(Name = "Responsável")]
        public string? IDSchwarzUserPlanoControle { get; set; }
        public virtual SchwarzUser? SchwarzUserPlanoControle { get; set; }

        [Display(Name = "Prazo")]
        public DateTime? PrazoPlanoControle { get; set; }

        [Display(Name = "Realizado?")]
        public bool? RealizadoPlanoControle { get; set; }



        [Display(Name = "É possível utilizar Poka Yoke?")]
        [Required(ErrorMessage = "Selecione a opção")]
        public bool UtilizarPokaYoke { get; set; }

        [Display(Name = "Qual?")]
        public string? QualPokaYoke { get; set; }

        [ForeignKey("SchwarzUserPokaYoke")]
        [Display(Name = "Responsável")]
        public string? IDSchwarzUserPokaYoke { get; set; }
        public virtual SchwarzUser? SchwarzUserPokaYoke { get; set; }

        [Display(Name = "Prazo")]
        public DateTime? PrazoPokaYoke { get; set; }

        [Display(Name = "Realizado?")]
        public bool? RealizadoPokaYoke { get; set; }



        [Display(Name = "É necessário aplicar Treinamento?")]
        [Required(ErrorMessage = "Selecione a opção")]
        public bool AplicarTreinamento { get; set; }

        [Display(Name = "Qual?")]
        public string? QualTreinamento { get; set; }

        [ForeignKey("SchwarzUserTreinamento")]
        [Display(Name = "Responsável")]
        public string? IDSchwarzUserTreinamento { get; set; }
        public virtual SchwarzUser? SchwarzUserTreinamento { get; set; }

        [Display(Name = "Prazo")]
        public DateTime? PrazoTreinamento { get; set; }

        [Display(Name = "Realizado?")]
        public bool? RealizadoTreinamento { get; set; }



        [Display(Name = "É necessário emitir Alerta da Qualidade?")]
        [Required(ErrorMessage = "Selecione a opção")]
        public bool EmitirAlertaQualidade { get; set; }

        [Display(Name = "Qual?")]
        public string? QualAlertaQualidade { get; set; }

        [ForeignKey("SchwarzUserAlertaQualidade")]
        [Display(Name = "Responsável")]
        public string? IDSchwarzUserAlertaQualidade { get; set; }
        public virtual SchwarzUser? SchwarzUserAlertaQualidade { get; set; }

        [Display(Name = "Prazo")]
        public DateTime? PrazoAlertaQualidade { get; set; }

        [Display(Name = "Realizado?")]
        public bool? RealizadoAlertaQualidade { get; set; }



        [ForeignKey("SchwarzUserVerificacao")]
        [Display(Name = "Responsável")]
        public string? IDSchwarzUserVerificacao{ get; set; }
        public virtual SchwarzUser? SchwarzUserVerificacao { get; set; }

        [Display(Name = "Data")]
        public DateTime? DataVerificacao { get; set; }
        [Display(Name = "Indicador")]
        public string? IndicadorVerificacao { get; set; }
        [Display(Name = "Foi Eficaz?")]
        public bool? EficazVerificacao { get; set; }
        [Display(Name = "Metodologia")]
        public string? MetodologiaVerificacao { get; set; }

        [ForeignKey("NovaFSP")]
        [Display(Name = "Nova FSP")]
        public int? IDNovaFSP { get; set; }
        public virtual FSP? NovaFSP { get; set; }

        [ForeignKey("SchwarzUserNovaFSP")]
        [Display(Name = "Responsável Nova FSP")]
        public string? IDSchwarzUserNovaFSP { get; set; }
        public virtual SchwarzUser? SchwarzUserNovaFSP { get; set; }


        public FSP()
		{

		}
		public FSP(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
