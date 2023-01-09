using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class BoletoRepository : BaseRepository, IBoletoRepository
    {
        public SchwarzContext _context;
        public BoletoRepository()
        {

        }
        public BoletoRepository(SchwarzContext contexto) : base(contexto)
        {
            _context = contexto;
        }
    }
}
