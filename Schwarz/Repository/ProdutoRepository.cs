using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class ProdutoRepository : BaseRepository,IProdutoRepository

	{
		public SchwarzContext _context;
		public ProdutoRepository()
		{

		}
		public ProdutoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
