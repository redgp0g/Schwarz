using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
		public SchwarzContext _context;
		public ClienteRepository()
		{

		}
		public ClienteRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
