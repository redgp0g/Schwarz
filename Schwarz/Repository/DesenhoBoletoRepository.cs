using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class DesenhoBoletoRepository : BaseRepository, IDesenhoBoletoRepository

	{
		public SchwarzContext _context;
		public DesenhoBoletoRepository()
		{

		}
		public DesenhoBoletoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
		public DesenhoBoleto GetDesenhoBoletoById(int id)
		{
			return _context.DesenhoBoleto.Find(id);
		}
	}
}
