using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class FluxoOperacaoRepository : BaseRepository, IFluxoOperacaoRepository

	{
		public SchwarzContext _context;
		public FluxoOperacaoRepository()
		{

		}
		public FluxoOperacaoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
