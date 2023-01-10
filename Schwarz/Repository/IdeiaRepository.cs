using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class IdeiaRepository : BaseRepository, IIdeiaRepository

	{
		public SchwarzContext _context;
		public IdeiaRepository()
		{

		}
		public IdeiaRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
