using Latelier.WebApp.MVC.Models;
using MJ.Solutions.Core.Communication;
using System;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Services
{
	public interface IComprasBFFService
	{
		Task<CarrinhoViewModel> ObterCarrinho();
		Task<int> ObterQuantidadeCarrinho();
		Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel produto);
		Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto);
		Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
		Task<ResponseResult> AplicarVoucherCarrinho(string voucher);

	}
}
