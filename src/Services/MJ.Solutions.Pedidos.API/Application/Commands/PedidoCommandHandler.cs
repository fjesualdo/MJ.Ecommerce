using FluentValidation.Results;
using MediatR;
using MJ.Solutions.Core.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedidos.API.Application.Commands
{
	public class PedidoCommandHandler : CommandHandler, IRequestHandler<AdicionarPedidoCommand, ValidationResult>
	{
		public Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
		{
			// Validarção do comando

			// Mapear pedido

			// Aplicar voucher se houver

			// Validar pedido

			// Processar pagamento

			// Se pagamento tudo OK!

			// Adicionar Evento

			// Adicionar Pedido Repositorio

			// Persistir dados de pedido e voucher


			return null;
		}
	}
}
