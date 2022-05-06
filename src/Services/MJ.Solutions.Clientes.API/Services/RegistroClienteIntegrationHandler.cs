﻿using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MJ.Solutions.Clientes.API.Application.Commands;
using MJ.Solutions.Core.Mediator;
using MJ.Solutions.Core.Messages.Integration;
using MJ.Solutions.Core.Messaging;
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
			SetResponder();
			return Task.CompletedTask;
		}

		private void SetResponder()
		{
			_bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
					await RegistrarCliente(request));

			_bus.AdvancedBus.Connected += OnConnect;
		}

		private void OnConnect(object s, EventArgs e)
		{
			SetResponder();
		}


		private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
		{
			var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
			ValidationResult sucesso;

			using (var scope = _serviceProvider.CreateScope())
			{
				var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
				sucesso = await mediator.SendCommand(clienteCommand);
			}

			return new ResponseMessage(sucesso);
		}
	}
}
