﻿using Microsoft.AspNetCore.Identity;
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

		[ForeignKey("User")]
		[Display(Name = "Usuário Logado")]
		public string IDUser { get; set; }
		public virtual SchwarzUser? User { get; set; }

		[Display(Name = "Descrição da Ideia")]
		[Required(ErrorMessage = "Descreva a ideia")]
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		public string Status { get; set; }

		[Display(Name = "Ganho")]
        public string Ganho { get; set; }

        public string? Investimento { get; set; }
		public string? Feedback { get; set; }

		[Display(Name = "Nome da Equipe")]
        public string? NomeEquipe { get; set; }

		public virtual List<EquipeIdeia>? EquipeIdeia { get; set; }

		[NotMapped]
		public IEnumerable<int>? Participantes { get; set; }

		public Ideia()
		{

		}
		public Ideia(SchwarzContext contexto)
		{
			_context = contexto;
		}
	}
}
