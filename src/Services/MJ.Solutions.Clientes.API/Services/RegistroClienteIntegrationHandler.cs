using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MJ.Solutions.Clientes.API.Application.Commands;
using MJ.Solutions.Core.Mediator;
using MJ.Solutions.Core.Messages.Integration;
using MJ.Solutions.MessageBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MJ.Solutions.Clientes.API.Services
{
	public class RegistroClienteIntegrationHandler : BackgroundService
	{
		private readonly IMessageBus _bus;
		private readonly IServiceProvider _serviceProvider;


		public RegistroClienteIntegrationHandler(IServiceProvider serviceProvider, IMessageBus bus)
		{
			_serviceProvider = serviceProvider;
			_bus = bus;
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(responder: async request => await RegistrarCliente(request));

			return Task.CompletedTask;

		}

		private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
		{
			var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
			ValidationResult sucesso;

			using (var scope = _serviceProvider.CreateScope())
			{
				var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
				sucesso = await mediator.EnviarComando(clienteCommand);
			}

			return new ResponseMessage(sucesso);
		}
	}
}
