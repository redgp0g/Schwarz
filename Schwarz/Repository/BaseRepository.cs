using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Repository.Interfaces;

namespace Schwarz.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly SchwarzContext _context;
		public BaseRepository()
        {

        }
        public BaseRepository(SchwarzContext contexto)
        {
            _context = contexto;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }


		public IEnumerable<EquipeFSP> GetEquipesFSPs()
		{
			return _context.EquipeFSP.ToList();
		}
		public IEnumerable<EquipeIdeia> GetEquipeIdeias()
		{
			return _context.EquipeIdeia.ToList();
		}

        public IEnumerable<Falha> GetFalhas()
        {
            return _context.Falha.ToList();
        }

		public IEnumerable<FSP> GetFSPs()
		{
			return _context.FSP.ToList();
		}

		public IEnumerable<Funcionario> GetFuncionarios()
        {
            return _context.Funcionario.ToList();
        }

        public IEnumerable<Funcionario> GetFuncionariosAtivos()
        {
            return _context.Funcionario.Where(x => x.Ativo == true).ToList().OrderBy(x => x.Nome);
        }
        public IEnumerable<Ideia> GetIdeias()
		{
			return _context.Ideia.ToList();
		}

		public IEnumerable<PlanoAcao> GetPlanoAcaos()
		{
			return _context.PlanoAcao.ToList();
		}


    }
}
