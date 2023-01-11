using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class PlanoAcaoRepository : BaseRepository, IPlanoAcaoRepository

	{
		public SchwarzContext _context;
		public PlanoAcaoRepository()
		{

		}
		public PlanoAcaoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
