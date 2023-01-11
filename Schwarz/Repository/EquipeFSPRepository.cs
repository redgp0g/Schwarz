using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class EquipeFSPRepository : BaseRepository,IEquipeFSPRepository
	{
        public SchwarzContext _context;
        public EquipeFSPRepository()
        {

        }
        public EquipeFSPRepository(SchwarzContext contexto)
        {
            _context = contexto;
        }

	}
}
