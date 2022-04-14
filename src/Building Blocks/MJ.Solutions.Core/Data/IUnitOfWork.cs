using System.Threading.Tasks;

namespace MJ.Solutions.Core.Data
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();
	}
}
