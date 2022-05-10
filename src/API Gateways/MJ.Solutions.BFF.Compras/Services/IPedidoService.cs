using System.Collections.Generic;
using System.Threading.Tasks;
using MJ.Solutions.BFF.Compras.Models;
using MJ.Solutions.Core.Communication;

namespace MJ.Solutions.BFF.Compras.Services
{
	public interface IPedidoService
	{
		Task<ResponseResult> FinalizarPedido(PedidoDTO pedido);
		Task<PedidoDTO> ObterUltimoPedido();
		Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId();
		Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
	}
}
