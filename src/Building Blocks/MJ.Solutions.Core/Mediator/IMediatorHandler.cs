using FluentValidation.Results;
using MJ.Solutions.Core.Messages;
using System.Threading.Tasks;

namespace MJ.Solutions.Core.Mediator
{
	public interface IMediatorHandler
	{
		Task PublicarEvento<T>(T evento) where T : Event;
		Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
	}
}