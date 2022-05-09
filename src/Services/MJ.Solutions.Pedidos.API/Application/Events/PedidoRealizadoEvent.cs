using MJ.Solutions.Core.Messaging;
using System;

namespace MJ.Solutions.Pedidos.API.Application.Events
{
	public class PedidoRealizadoEvent : Event
	{
		public Guid PedidoId { get; private set; }
		public Guid ClienteId { get; private set; }

		public PedidoRealizadoEvent(Guid pedidoId, Guid clienteId)
		{
			PedidoId = pedidoId;
			ClienteId = clienteId;
		}
	}
}
