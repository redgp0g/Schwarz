using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class FSPRepository : BaseRepository,IFSPRepository
    {
        public SchwarzContext _context;
        public FSPRepository()
        {

        }
        public FSPRepository(SchwarzContext contexto)
        {
            _context = contexto;
        }
        

	}
}
