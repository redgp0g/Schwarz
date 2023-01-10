using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Xml.Linq;

namespace Schwarz.Models
{
	public class Operacao : OperacaoRepository
	{
		[Key]
		public int IDOperacao { get; set; }

		[Required(ErrorMessage = "Digite a Sequencia")]
		[Display(Name = "Sequência")]
		public int Sequencia { get; set; }

		[Required(ErrorMessage = "Digite a SubSequencia")]
		public int SubSequencia { get; set; }

		[Required(ErrorMessage = "Descreva a operação")]
		[Display(Name = "Descrição da Operação")]
		public string Descricao { get; set; }

		[Required(ErrorMessage = "Selecione o Procedimento")]
		public string Procedimento { get; set; }
		public virtual ICollection<Processo>? Processos { get; set; }
		public Operacao()
		{

		}
		public Operacao(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
