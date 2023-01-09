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

        public IEnumerable<DesenhoBoleto> GetDesenhosBoletos()
        {
            return _context.DesenhoBoleto.ToList();
        }

        public IEnumerable<Desenho> GetDesenhos()
        {
            return _context.Desenho.ToList();
        }

        public IEnumerable<Funcionario> GetFuncionarios()
        {
            return _context.Funcionario.ToList();
        }

        public IEnumerable<Produto> GetProdutos()
        {
            return _context.Produto.ToList();
        }
        public IEnumerable<Operacao> GetOperacoes()
        {
            return _context.Operacao.ToList();
        }
        public IEnumerable<Processo> GetProcessos()
        {
            return _context.Processo.ToList();
        }
        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Cliente.ToList();
        }
        public IEnumerable<Fluxo> GetFluxos()
        {
            return _context.Fluxo.ToList();
        }
        public IEnumerable<Boleto> GetBoletos()
        {
            return _context.Boleto.ToList();
        }
    }
}
