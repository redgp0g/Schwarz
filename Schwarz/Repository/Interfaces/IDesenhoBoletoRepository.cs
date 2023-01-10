using Schwarz.Models;

namespace Schwarz.Repository.Interfaces
{
    public interface IDesenhoBoletoRepository : IBaseRepository
	{
		DesenhoBoleto GetDesenhoBoletoById(int id);
	}
}
