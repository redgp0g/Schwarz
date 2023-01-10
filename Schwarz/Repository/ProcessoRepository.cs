using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class ProcessoRepository : BaseRepository, IProcessoRepository

	{
		public SchwarzContext _context;
		public ProcessoRepository()
		{

		}
		public ProcessoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
