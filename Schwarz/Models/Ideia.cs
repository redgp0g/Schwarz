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
		public int IDIdeia { get; set; }

		[Display(Name = "Descrição da Ideia")]
		[Required(ErrorMessage = "Descreva a ideia")]
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		[Display(Name = "Data de Implantação")]
		public DateTime? DataImplantacao { get; set; }
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

		[Display(Name = "Ganho Realizado")]
		public decimal? GanhoRealizado { get; set; }

		public virtual ICollection<EquipeIdeia> EquipeIdeia { get; set; }
		[Column(TypeName = "varbinary(max)")]
		public byte[]? Anexo { get; set; }
		[NotMapped]
		[Required(ErrorMessage = "Selecione pelo menos um funcionário")]
		public List<int>? Participantesids { get; set; }

        [NotMapped]
		public string DataFormatada => Data.ToString("dd/MM/yyyy");

		public Ideia()
		{

		}
		public Ideia(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
