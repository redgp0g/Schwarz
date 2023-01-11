using Schwarz.Models;

namespace Schwarz.Repository.Interfaces
{
    public interface IBaseRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
		IEnumerable<Boleto> GetBoletos();
		IEnumerable<CadastroOleo> GetCadastroOleos();
		IEnumerable<Cliente> GetClientes();
		IEnumerable<Desenho> GetDesenhos();
		IEnumerable<DesenhoBoleto> GetDesenhosBoletos();
		IEnumerable<EquipeFSP> GetEquipesFSPs();
		IEnumerable<EquipeIdeia> GetEquipeIdeias();
		IEnumerable<Fluxo> GetFluxos();
		IEnumerable<FluxoOperacao> GetFluxoOperacaos();
		IEnumerable<FSP> GetFSPs();
		IEnumerable<Funcionario> GetFuncionarios();
		IEnumerable<Ideia> GetIdeias();
		IEnumerable<Maquina> GetMaquinas();
		IEnumerable<Operacao> GetOperacoes();
		IEnumerable<PlanoAcao> GetPlanoAcaos();
		IEnumerable<Processo> GetProcessos();
		IEnumerable<ProcessoProduto> GetProcessoProdutos();
		IEnumerable<Produto> GetProdutos();
    }
}
