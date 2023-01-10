using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class CadastroOleoRepository :BaseRepository, ICadastroOleoRepository
    {
		public SchwarzContext _context;
		public CadastroOleoRepository()
		{

		}
		public CadastroOleoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
