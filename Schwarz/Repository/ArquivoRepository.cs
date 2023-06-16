using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class ArquivoRepository : BaseRepository, IArquivoRepository
    {
		public SchwarzContext _context;
		public ArquivoRepository()
		{

		}
		public ArquivoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
