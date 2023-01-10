using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class EquipeIdeiaRepository : BaseRepository, IEquipeIdeiaRepository

	{
		public SchwarzContext _context;
		public EquipeIdeiaRepository()
		{

		}
		public EquipeIdeiaRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
