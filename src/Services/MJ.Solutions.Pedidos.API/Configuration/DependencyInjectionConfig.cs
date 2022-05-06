using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.Core.Mediator;
using MJ.Solutions.Pedidos.API.Application.Queries;
using MJ.Solutions.Pedidos.Domain;
using MJ.Solutions.Pedidos.Infra.Data;
using MJ.Solutions.Pedidos.Infra.Data.Repository;
using MJ.Solutions.WebAPI.Core.Usuario;

namespace MJ.Solutions.Pedidos.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			// API
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();

			// Commands


			// Events


			// Application
			services.AddScoped<IMediatorHandler, MediatorHandler>();
			services.AddScoped<IVoucherQueries, VoucherQueries>();

			// Data
			//services.AddScoped<IPedidoRepository, PedidoRepository>();
			services.AddScoped<IVoucherRepository, VoucherRepository>();
			services.AddScoped<PedidosContext>();
		}
	}
}
