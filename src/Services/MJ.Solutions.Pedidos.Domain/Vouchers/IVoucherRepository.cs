using MJ.Solutions.Core.Data;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedidos.Domain
{
	public interface IVoucherRepository : IRepository<Voucher>
	{
		Task<Voucher> ObterVoucherPorCodigo(string codigo);
	}
}
