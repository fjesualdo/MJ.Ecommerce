using MJ.Solutions.Pagamentos.API.Models;
using System.Threading.Tasks;

namespace MJ.Solutions.Pagamentos.API.Facade
{
	public interface IPagamentoFacade
	{
		Task<Transacao> AutorizarPagamento(Pagamento pagamento);
	}
}
