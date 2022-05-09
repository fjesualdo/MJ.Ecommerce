using MediatR;
using MJ.Solutions.MessageBus;
using System.Threading;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedidos.API.Application.Events
{
	public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
	{
		Task INotificationHandler<PedidoRealizadoEvent>.Handle(PedidoRealizadoEvent notification, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}
