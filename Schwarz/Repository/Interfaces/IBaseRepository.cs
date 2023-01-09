using Schwarz.Models;

namespace Schwarz.Repository.Interfaces
{
    public interface IBaseRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        IEnumerable<DesenhoBoleto> GetDesenhosBoletos();
        IEnumerable<Desenho> GetDesenhos();
        IEnumerable<Funcionario> GetFuncionarios();
        IEnumerable<Produto> GetProdutos();
        IEnumerable<Operacao> GetOperacoes();
        IEnumerable<Processo> GetProcessos();
        IEnumerable<Cliente> GetClientes();
        IEnumerable<Fluxo> GetFluxos();

    }
}
