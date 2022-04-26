using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.MessageBus;
using MJ.Solutions.Clientes.API.Services;
using MJ.Solutions.Core.Utils;

namespace MJ.Solutons.Clientes.API.Configuration
{
	public static class MessageBusConfig
	{
		public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus")).AddHostedService<RegistroClienteIntegrationHandler>()
				.AddHostedService<RegistroClienteIntegrationHandler>();

		}
	}
}
