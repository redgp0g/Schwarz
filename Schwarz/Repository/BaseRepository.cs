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

		public IEnumerable<Boleto> GetBoletos()
		{
			return _context.Boleto.ToList();
		}

		public IEnumerable<CadastroOleo> GetCadastroOleos()
		{
			return _context.CadastroOleo.ToList();
		}

		public IEnumerable<Cliente> GetClientes()
		{
			return _context.Cliente.ToList();
		}

		public IEnumerable<Desenho> GetDesenhos()
		{
			return _context.Desenho.ToList();
		}
		public IEnumerable<DesenhoBoleto> GetDesenhosBoletos()
        {
            return _context.DesenhoBoleto.ToList();
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

        public IEnumerable<Fluxo> GetFluxos()
		{
			return _context.Fluxo.ToList();
		}

		public IEnumerable<FluxoOperacao> GetFluxoOperacaos()
		{
			return _context.FluxoOperacao.ToList();
		}
		public IEnumerable<FSP> GetFSPs()
		{
			return _context.FSP.ToList();
		}

		public IEnumerable<Funcionario> GetFuncionarios()
        {
            return _context.Funcionario.ToList();
        }

		public IEnumerable<Ideia> GetIdeias()
		{
			return _context.Ideia.ToList();
		}

		public IEnumerable<Maquina> GetMaquinas()
		{
			return _context.Maquina.ToList();
		}

		public IEnumerable<Operacao> GetOperacoes()
		{
			return _context.Operacao.ToList();
		}

		public IEnumerable<Processo> GetProcessos()
		{
			return _context.Processo.ToList();
		}

		public IEnumerable<PlanoAcao> GetPlanoAcaos()
		{
			return _context.PlanoAcao.ToList();
		}

		public IEnumerable<ProcessoProduto> GetProcessoProdutos()
		{
			return _context.ProcessoProduto.ToList();
		}

		public IEnumerable<Produto> GetProdutos()
        {
            return _context.Produto.ToList();
        }
        

	}
}
