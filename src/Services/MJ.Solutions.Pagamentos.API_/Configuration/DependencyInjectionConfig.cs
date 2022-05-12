using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.BFF.Compras.Services;
using MJ.Solutions.Pagamentos.API.Data;
using MJ.Solutions.Pagamentos.API.Data.Repository;
using MJ.Solutions.Pagamentos.API.Model;
using MJ.Solutions.WebAPI.Core.Usuario;

namespace MJ.Solutions.Pagamentos.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();

			services.AddScoped<IPagamentoService, PagamentoService>();
			//services.AddScoped<IPagamentoFacade, PagamentoCartaoCreditoFacade>();

			services.AddScoped<IPagamentoRepository, PagamentoRepository>();
			services.AddScoped<PagamentosContext>();
		}
	}
}
