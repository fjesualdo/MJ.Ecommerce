using MJ.Solutions.Core.Messages;
using MJ.Solutions.Core.Messaging;
using System;
using System.Collections.Generic;

namespace MJ.Solutions.Core.Domain
{
	public abstract class Entity
	{
		public Guid Id { get; set; }

		protected Entity()
		{
			Id = Guid.NewGuid();
		}

		private List<Event> _domainEvents;
		public IReadOnlyCollection<Event> Notificacoes => _domainEvents?.AsReadOnly();

		public void AddDomainEvent(Event domainEvent)
		{
			_domainEvents = _domainEvents ?? new List<Event>();
			_domainEvents.Add(domainEvent);
		}

		public void RemoveDomainEvent(Event domainEvent)
		{
			_domainEvents?.Remove(domainEvent);
		}

		public void ClearDomainEvents()
		{
			_domainEvents?.Clear();
		}

		#region BaseBehaviours

		public override bool Equals(object obj)
		{
			var compareTo = obj as Entity;

			if (ReferenceEquals(this, compareTo)) return true;
			if (ReferenceEquals(null, compareTo)) return false;

			return Id.Equals(compareTo.Id);
		}

		public static bool operator ==(Entity a, Entity b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
				return true;

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
				return false;

			return a.Equals(b);
		}

		public static bool operator !=(Entity a, Entity b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode() ^ 93 + Id.GetHashCode();
		}

		public override string ToString()
		{
			return $"{GetType().Name} [Id={Id}]";
		}

		#endregion BaseBehaviours
	}
}
