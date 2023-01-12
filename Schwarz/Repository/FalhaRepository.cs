using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class FalhaRepository : BaseRepository, IFalhaRepository

    {
		public SchwarzContext _context;
		public FalhaRepository()
		{

		}
		public FalhaRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
