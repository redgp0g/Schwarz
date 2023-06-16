using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class IdeiaArquivoRepository : BaseRepository, IIdeiaArquivoRepository
    {
		public SchwarzContext _context;
		public IdeiaArquivoRepository()
		{

		}
		public IdeiaArquivoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
