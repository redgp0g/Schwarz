﻿using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class Ideia
    {
		[Key]
		public int IDIdeia { get; set; }

		[Display(Name = "Descrição da Ideia")]
		[Required(ErrorMessage = "Descreva a ideia")]
		public string Descricao { get; set; } = string.Empty;
		public DateTime Data { get; set; } = DateTime.Now;

		[Display(Name = "Data de Implantação")]
		public DateOnly? DataImplantacao { get; set; }

		[Required(ErrorMessage = "Selecione a situação da ideia!")]
		public string Status { get; set; } = "Recebida";
        public string? Ganho { get; set; }
        public string? Investimento { get; set; }
		public string? Feedback { get; set; }

		[Display(Name = "Nome da Equipe")]
        public string? NomeEquipe { get; set; }
		
		[Display(Name = "Ordem de Serviço")]
		public string? OrdemServico { get; set; }

		[Display(Name = "N° Solicitação de Análise")]
		public int? SolicitacaoAnalise { get; set; }

		[Display(Name = "Ganho Realizado")]
		public decimal? GanhoRealizado { get; set; }

		public virtual ICollection<IdeiaEquipe>? IdeiaEquipe { get; set; }
		public virtual ICollection<IdeiaAnexo>? IdeiaAnexo { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Selecione pelo menos um funcionário")]
		public List<int>? Participantesids { get; set; }
        [NotMapped]
        public IEnumerable<string>? NomesEquipe { get; set; }
        [NotMapped]
        public string DataFormatada => Data.ToString("dd/MM/yyyy");
	}
}