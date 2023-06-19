using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class PlanoControleRepository : BaseRepository, IPlanoControleRepository
    {
		public SchwarzContext _context;
		public PlanoControleRepository()
		{

		}
		public PlanoControleRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
