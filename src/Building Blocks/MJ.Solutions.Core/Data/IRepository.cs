using MJ.Solutions.Core.DomainObjects;
using System;

namespace MJ.Solutions.Core.Data
{
	public interface IRepository<T> : IDisposable where T : IAggregateRoot
	{
	}
}
