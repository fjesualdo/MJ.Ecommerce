using MJ.Solutions.Core.Data;
using MJ.Solutions.Pedido.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedido.Infra.Data.Repository
{
  public class VoucherRepository : IVoucherRepository
  {
    private readonly PedidosContext _context;

    public VoucherRepository(PedidosContext context)
    {
      _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;


    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
