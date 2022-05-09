using MJ.Solutions.Pedidos.API.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedidos.API.Application.Queries
{
	public interface IPedidoQueries
  {
    Task<PedidoDTO> ObterUltimoPedido(Guid clienteId);
    Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId(Guid clienteId);
  }
}
