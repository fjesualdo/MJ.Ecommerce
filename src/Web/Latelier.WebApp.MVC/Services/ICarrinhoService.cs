using Latelier.WebApp.MVC.Models;
using MJ.Solutions.Core.Communication;
using System;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Services
{
	public interface ICarrinhoService
	{
		Task<CarrinhoViewModel> ObterCarrinho();
		Task<ResponseResult> AdicionarItemCarrinho(ItemProdutoViewModel produto);
		Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto);
		Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
	}
}
