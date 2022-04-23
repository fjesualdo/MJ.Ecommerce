using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.Clientes.API.Application.Commands;
using MJ.Solutions.Core.Mediator;

namespace MJ.Solutions.Clientes.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IMediatorHandler, MediatorHandler>();
			services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
		}
	}
}
