using Schwarz.Models;

namespace Schwarz.Repository.Interfaces
{
    public interface IDesenhoRepository : IBaseRepository
	{
		Desenho GetDesenhoById(int id);
		List<DesenhoBoleto> GetDesenhosBoletosByDesenhoID(int id);
		Desenho GetDesenhoByCodigo(int codigo);
	}
}
