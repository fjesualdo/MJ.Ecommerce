using System;

namespace MJ.Solutions.Core.Messaging
{
	public abstract class DomainEvent : Event
	{
		protected DomainEvent(Guid aggregateId)
		{
			AggregateId = aggregateId;
		}
	}
}
