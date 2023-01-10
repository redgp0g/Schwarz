using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class ProcessoProdutoRepository : BaseRepository, IProcessoProdutoRepository

	{
		public SchwarzContext _context;
		public ProcessoProdutoRepository()
		{

		}
		public ProcessoProdutoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
