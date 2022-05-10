﻿using Latelier.WebApp.MVC.Models;
using MJ.Solutions.Core.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Services
{
	public interface IComprasBFFService
	{
    // Carrinho
    Task<CarrinhoViewModel> ObterCarrinho();
    Task<int> ObterQuantidadeCarrinho();
    Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel carrinho);
    Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel carrinho);
    Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
    Task<ResponseResult> AplicarVoucherCarrinho(string voucher);

    // Pedido
    Task<ResponseResult> FinalizarPedido(PedidoTransacaoViewModel pedidoTransacao);
    Task<PedidoViewModel> ObterUltimoPedido();
    Task<IEnumerable<PedidoViewModel>> ObterListaPorClienteId();
    PedidoTransacaoViewModel MapearParaPedido(CarrinhoViewModel carrinho, EnderecoViewModel endereco);
  }
}
