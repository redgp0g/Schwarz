using Schwarz.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;

namespace Schwarz.Models
{
	public class Fluxo : FluxoRepository
	{
		[Key]
		public int IDFluxo { get; set; }
		public string CodigoFL { get; set; }

		[ForeignKey("Produto")]
		public int IDProduto { get; set; }
		public virtual Produto? Produto { get; set; }

		[ForeignKey("FuncionarioCriador")]
		public int IDFuncionarioCriador { get; set; }
		public virtual Funcionario? FuncionarioCriador { get; set; }

		[ForeignKey("FuncionarioAprovador")]
		public int IDFuncionarioAprovador { get; set; }
		public virtual Funcionario? FuncionarioAprovador { get; set; }

		[Display(Name = "Data de Criação")]
		public DateOnly DataCriacao { get; set; }
		public DateOnly Data { get; set; }

		[Display(Name = "Aplicação")]
		public string Aplicacao { get; set; }

		[Display(Name = "Revisão")]
		public int Revisao { get; set; }
		[Display(Name = "Descrição da Revisão")]
		public string DescricaoRevisao { get; set; }
		public virtual ICollection<FluxoOperacao>? FluxoOperacoes { get; set; }
		private readonly SchwarzContext _context;
		public Fluxo()
		{
		}
		public Fluxo(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
		public List<FluxoOperacao> CarregarOPsFluxo(int IDFLuxo)
		{
			return _context.FluxoOperacao.Where(x => x.IDFluxo == IDFLuxo).ToList();
		}

		public List<Operacao> CarregarNovasOperacoes(int IDFLuxo)
		{
			var operacoes = _context.Operacao.ToList();
			var fluxo = _context.FluxoOperacao.Where(x => x.IDFluxo == IDFLuxo).ToList();
			foreach (var item in fluxo)
			{
				operacoes.Remove(item.Operacao);
			}
			return operacoes;
		}

	}
}
