using Microsoft.EntityFrameworkCore;
using MJ.Solutions.Core.Data;
using MJ.Solutions.Pedidos.Domain;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedidos.Infra.Data.Repository
{
	public class VoucherRepository : IVoucherRepository
	{
		private readonly PedidosContext _context;

		public VoucherRepository(PedidosContext context)
		{
			_context = context;
		}

		public IUnitOfWork UnitOfWork => _context;

		public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
		{
			return await _context.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
