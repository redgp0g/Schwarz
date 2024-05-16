using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class Funcionario
    {
        [Key]
        public int IDFuncionario { get; set; }
		public int? Matricula { get; set; }
		public string Nome { get; set; }
        public string? Setor { get; set; }
        public string? CentroCusto { get; set; }
        public DateTime? DataNascimento { get; set; }
		public bool Ativo { get; set; }
		public string? Turno { get; set; }
		public string? Email { get; set; }

        [ForeignKey("FuncionarioLider")]
        public int? IDLider { get; set; }
        public virtual Funcionario? FuncionarioLider { get; set; }
		public string? Cargo { get; set; }
		public string? Ramal { get; set; }
		public byte[]? Foto { get; set; }
		public string? Telefone { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public int? NumeroCentroCusto { get; set; }
        public virtual SchwarzUser? User { get; set; }
        private readonly SchwarzContext _context;
        public virtual ICollection<IdeiaEquipe>? IdeiaEquipe { get; set; }


        [NotMapped]
		public int QuantidadeIdeias2023
		{
			get
			{
                return IdeiaEquipe != null ? IdeiaEquipe.Count(e => e.Ideia.Data.Year == 2023) : 0;
            }
		}

		[NotMapped]
		public int QuantidadeIdeiasImplementadas2023
		{
			get
			{
                return IdeiaEquipe != null ? IdeiaEquipe.Count(e => e.Ideia.Status == "Implementada" && (e.Ideia.Data.Year == 2023 || (e.Ideia.DataImplantacao.HasValue && e.Ideia.DataImplantacao.Value.Year == 2023))) : 0;
            }
		}

        [NotMapped]
        public string PrimeiroUltimoNome
        {
            get
            {
                string[] nomes = Nome.Split(' ');
                if (nomes.Length < 2)
                    return Nome;

                return nomes[0] + " " + nomes[nomes.Length - 1];
            }
        }

        public Funcionario()
        {

        }
        public Funcionario(SchwarzContext contexto)
        {
            _context = contexto;
        }
    }

    public class FuncionarioViewModel
    {
        public int? Matricula { get; set; }
        public string Nome { get; set; }
        public int IDFuncionario { get; set; }
        public string Setor { get; set; }
        public string Turno { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public bool Ativo{ get; set; }
    }

}