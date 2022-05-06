using System.Threading.Tasks;
using MJ.Solutions.BFF.Compras.Models;

namespace MJ.Solutions.BFF.Compras.Services
{
	public interface IPedidoService
  {
    Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
  }
}
