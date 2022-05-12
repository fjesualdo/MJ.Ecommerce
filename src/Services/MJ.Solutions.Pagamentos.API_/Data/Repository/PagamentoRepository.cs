using Microsoft.EntityFrameworkCore;
using MJ.Solutions.Core.Data;
using MJ.Solutions.Pagamentos.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJ.Solutions.Pagamentos.API.Data.Repository
{
	public class PagamentoRepository : IPagamentoRepository
	{
		private readonly PagamentosContext _context;

		public PagamentoRepository(PagamentosContext context)
		{
			_context = context;
		}

		public IUnitOfWork UnitOfWork => _context;

		public void AdicionarPagamento(Pagamento pagamento)
		{
			_context.Pagamentos.Add(pagamento);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
