using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class DesenhoRepository : BaseRepository, IDesenhoRepository

	{
		public SchwarzContext _context;
		public DesenhoRepository()
		{

		}
		public DesenhoRepository(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}

		public Desenho GetDesenhoByCodigo(int codigo)
		{
			return _context.Desenho.FirstOrDefault(x => x.Processo.CodigoInterno == codigo || x.Produto.CodigoCliente == codigo);
		}

		public Desenho GetDesenhoById(int id)
		{
			return _context.Desenho.Find(id);
		}

		public List<DesenhoBoleto> GetDesenhosBoletosByDesenhoID(int ID)
		{
			return _context.DesenhoBoleto.Where(x => x.IDDesenho == ID).ToList();
		}
	}
}
