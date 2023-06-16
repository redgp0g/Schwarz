using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
	public class PlanoControle : PlanoControleRepository
	{
		[Key]
		public int IDPlanoControle { get; set; }
		public int Revisao { get; set; }
        public DateTime DataOrigem { get; set; }
		public DateTime DataAtualizacao { get; set; }
		public  Status{ get; set; }
        public DateTime DataUpload{ get; set; }

        public PlanoControle()
		{

		}
		public PlanoControle(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

	}
}
