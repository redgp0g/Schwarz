using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class CotaRepository : BaseRepository, ICotaRepository
	{
		public SchwarzContext _context;
		public CotaRepository()
		{

		}
		public CotaRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
