using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class FluxoRepository : BaseRepository, IFluxoRepository

	{
		public SchwarzContext _context;
		public FluxoRepository()
		{

		}
		public FluxoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
