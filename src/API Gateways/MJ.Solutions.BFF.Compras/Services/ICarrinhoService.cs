using MJ.Solutions.BFF.Compras.Models;
using MJ.Solutions.Core.Communication;
using System;
using System.Threading.Tasks;

namespace MJ.Solutions.BFF.Compras.Services
{
	public interface ICarrinhoService
	{
		Task<CarrinhoDTO> ObterCarrinho();
		Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDTO produto);
		Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDTO carrinho);
		Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
	}
}
