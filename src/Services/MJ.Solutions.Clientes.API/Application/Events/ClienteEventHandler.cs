using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MJ.Solutions.Clientes.API.Application.Events
{
  public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
  {
    public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
    {
      // Enviar evento de confirmação
      return Task.CompletedTask;
    }
  }
}
