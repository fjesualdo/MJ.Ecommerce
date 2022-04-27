using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.Carrinho.API.Data;
using MJ.Solutions.WebAPI.Core.Usuario;

namespace MJ.Solutions.Carrinho.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();
			services.AddScoped<CarrinhoContext>();
		}
	}
}
