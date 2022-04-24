using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.Clientes.API.Application.Commands;
using MJ.Solutions.Clientes.API.Application.Events;
using MJ.Solutions.Clientes.API.Data;
using MJ.Solutions.Clientes.API.Data.Repository;
using MJ.Solutions.Clientes.API.Models;
using MJ.Solutions.Core.Mediator;

namespace MJ.Solutions.Clientes.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IMediatorHandler, MediatorHandler>();

			services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
			
			services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<ClientesContext>();
		}
	}
}
