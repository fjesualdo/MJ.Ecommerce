using MJ.Solutions.Core.Messages;
using System;

namespace MJ.Solutions.Pedidos.Integration
{
	public class PedidoRealizadoIntegrationEvent : IntegrationEvent
	{
		public Guid ClienteId { get; private set; }

		public PedidoRealizadoIntegrationEvent(Guid clienteId)
		{
			ClienteId = clienteId;
		}
	}
}
