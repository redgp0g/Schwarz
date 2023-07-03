using Schwarz.Data;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class FuncionarioRepository : BaseRepository, IFuncionarioRepository

    {
        public SchwarzContext _context;
        public FuncionarioRepository()
        {

        }
        public FuncionarioRepository(SchwarzContext contexto) : base(contexto)
        {
            _context = contexto;
        }
    }
}