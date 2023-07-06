using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PlanoControleAnexo
	{
		[Key]
		public int IDIdeiaAnexo { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[] Anexo { get; set; }
        public string TipoMIME { get; set; }

		[ForeignKey("PlanoControle")]
        public int IDPlanoControle { get; set; }
        public virtual PlanoControle? PlanoControle { get; set; }

		private readonly SchwarzContext _context;
	
        public PlanoControleAnexo()
		{

		}
		public PlanoControleAnexo(SchwarzContext contexto)
		{
			_context = contexto;
		}

        public PlanoControleAnexo(string nome,byte[] anexo, string tipoMIME, int iDPlanocontrole)
        {
            Nome = nome;
            Anexo = anexo;
            TipoMIME = tipoMIME;
            IDPlanoControle = iDPlanocontrole;
        }
    }
}
