using MJ.Solutions.Core.Messaging;
using MJ.Solutions.Pagamentos.API.Models;
using System;
using System.Threading.Tasks;

namespace MJ.Solutions.Pagamentos.API.Services
{
	public interface IPagamentoService
	{
		Task<ResponseMessage> AutorizarPagamento(Pagamento pagamento);
		//Task<ResponseMessage> CapturarPagamento(Guid pedidoId);
		//Task<ResponseMessage> CancelarPagamento(Guid pedidoId);
	}
}
