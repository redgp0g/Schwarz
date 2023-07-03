using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Models;

namespace Schwarz.Repository.Interfaces
{
    public interface IBaseRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
		IEnumerable<EquipeFSP> GetEquipesFSPs();
		IEnumerable<EquipeIdeia> GetEquipeIdeias();
        IEnumerable<Falha> GetFalhas();
		IEnumerable<FSP> GetFSPs();
		IEnumerable<Funcionario> GetFuncionarios();
        IEnumerable<Funcionario> GetFuncionariosAtivos();
        IEnumerable<Ideia> GetIdeias();
		IEnumerable<PlanoAcao> GetPlanoAcaos();
    }
}
