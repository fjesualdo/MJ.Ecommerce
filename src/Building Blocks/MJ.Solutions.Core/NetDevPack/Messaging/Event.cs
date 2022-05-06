using MediatR;
using System;

namespace MJ.Solutions.Core.Messaging
{
	public class Event : Message, INotification
	{
		public DateTime Timestamp { get; private set; }

		protected Event()
		{
			Timestamp = DateTime.Now;
		}
	}
}
