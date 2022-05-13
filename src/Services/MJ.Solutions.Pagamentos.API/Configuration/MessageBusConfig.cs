using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.Core.ExtensionMethods;
using MJ.Solutions.MessageBus;
using MJ.Solutions.Pagamentos.API.Services;

namespace MJ.Solutions.Pagamentos.API.Configuration
{
	public static class MessageBusConfig
	{
		public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
				.AddHostedService<PagamentoIntegrationHandler>();
		}
	}
}
