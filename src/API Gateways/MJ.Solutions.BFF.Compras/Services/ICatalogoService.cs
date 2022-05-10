using MJ.Solutions.BFF.Compras.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MJ.Solutions.BFF.Compras.Services
{
	public interface ICatalogoService
	{
		Task<ItemProdutoDTO> ObterPorId(Guid id);
		Task<IEnumerable<ItemProdutoDTO>> ObterItens(IEnumerable<Guid> ids);
	}
}
