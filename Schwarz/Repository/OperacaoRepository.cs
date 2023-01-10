using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class OperacaoRepository : BaseRepository, IOperacaoRepository

	{
		public SchwarzContext _context;
		public OperacaoRepository()
		{

		}
		public OperacaoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
