using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.Clientes.API.Data;
using MJ.Solutions.Clientes.API.Data.Repository;
using MJ.Solutions.Clientes.API.Models;

namespace MJ.Solutions.Clientes.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<ClientesContext>();
		}
	}
}
