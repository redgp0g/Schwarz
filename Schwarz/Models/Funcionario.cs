using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    public class Funcionario : FuncionarioRepository
    {
        [Key]
        public int IDFuncionario { get; set; }
		public int? Matricula { get; set; }
		public string Nome { get; set; }
        public string? Setor { get; set; }
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

		[NotMapped]
		public int QuantidadeIdeias2023
		{
			get
			{
				// Obtém a quantidade de ideias do funcionário no ano de 2023
				return _context.EquipeIdeia
					.Count(e => e.IDFuncionario == IDFuncionario &&
								e.Ideia.Data.Year == 2023);
			}
		}

		[NotMapped]
		public int QuantidadeIdeiasImplementadas2023
		{
			get
			{
				// Obtém a quantidade de ideias do funcionário no ano de 2023
				return _context.EquipeIdeia
					.Count(e => e.IDFuncionario == IDFuncionario &&(
					e.Ideia.Status == "Aplicada" &&				
					e.Ideia.Data.Year == 2023));
			}
		}

        [NotMapped]
        public string? PrimeiroUltimoNome
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
        public Funcionario(SchwarzContext contexto) : base(contexto)
        {
            _context = contexto;
        }
    }
}