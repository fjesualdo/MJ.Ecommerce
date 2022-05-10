using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.Clientes.API.Application.Commands;
using MJ.Solutions.Clientes.API.Application.Events;
using MJ.Solutions.Clientes.API.Data;
using MJ.Solutions.Clientes.API.Data.Repository;
using MJ.Solutions.Clientes.API.Models;
using MJ.Solutions.Clientes.API.Services;
using MJ.Solutions.Core.Mediator;
using MJ.Solutions.WebAPI.Core.Usuario;

namespace MJ.Solutions.Clientes.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();

			services.AddScoped<IMediatorHandler, MediatorHandler>();

			services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
			services.AddScoped<IRequestHandler<AdicionarEnderecoCommand, ValidationResult>, ClienteCommandHandler>();

			services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<ClientesContext>();
		}
	}
}
