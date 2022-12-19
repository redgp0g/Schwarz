﻿using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class Ideia
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
        [Required(ErrorMessage = "O Ganho é obrigatório")]
        public string Ganho { get; set; }

        [Required(ErrorMessage = "O Investimento é obrigatório")]
        public float Investimento { get; set; }
		public string? Feedback { get; set; }

		[Display(Name = "Nome da Equipe")]
		[Required(ErrorMessage = "O Nome da Equipe é obrigatório")]
        public string NomeEquipe { get; set; }

		public virtual List<EquipeIdeia>? EquipeIdeia { get; set; }

		[NotMapped]
		public List<int>? Participantes { get; set; }

		private readonly SchwarzContext _context;
		public Ideia()
		{

		}
		public Ideia(SchwarzContext contexto)
		{
			_context = contexto;
		}
		public List<Ideia> GetIdeias()
		{
			return _context.Ideia.ToList();
		}
		public List<Funcionario> GetFuncionarios()
		{
			return _context.Funcionario.ToList();
		}
	}
}
