using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.WebAPI.Core.Usuario;

namespace MJ.Solutions.BFF.Compras.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();
		}
	}
}
