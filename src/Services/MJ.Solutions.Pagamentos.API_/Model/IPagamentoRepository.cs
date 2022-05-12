using MJ.Solutions.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MJ.Solutions.Pagamentos.API.Model
{
	public interface IPagamentoRepository : IRepository<Pagamento>
	{
		void AdicionarPagamento(Pagamento pagamento);
		
	}
}
