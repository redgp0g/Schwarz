using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class MaquinaRepository : BaseRepository, IMaquinaRepository

	{
		public SchwarzContext _context;
		public MaquinaRepository()
		{

		}
		public MaquinaRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
