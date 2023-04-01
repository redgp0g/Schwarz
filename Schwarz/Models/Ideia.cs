using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class Ideia : IdeiaRepository
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IDIdeia { get; set; }

		[ForeignKey("User")]
		[Display(Name = "Usuário Logado")]
		public string IDUser { get; set; }
		public virtual SchwarzUser User { get; set; }

		[Display(Name = "Descrição da Ideia")]
		[Required(ErrorMessage = "Descreva a ideia")]
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		public string Status { get; set; }
        public string? Ganho { get; set; }
        public string? Investimento { get; set; }
		public string? Feedback { get; set; }

		[Display(Name = "Nome da Equipe")]
        public string? NomeEquipe { get; set; }
		
		[Display(Name = "N° da OS")]
		public int? OS { get; set; }

		[Display(Name = "N° Solicitação de Análise")]
		public int? SolicitacaoAnalise { get; set; }

		public virtual List<EquipeIdeia> EquipeIdeia { get; set; }

		[NotMapped]
		[Required(ErrorMessage = "Selecione pelo menos um funcionário")]
		public List<int> Participantesids { get; set; }


		public Ideia()
		{

		}
		public Ideia(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
