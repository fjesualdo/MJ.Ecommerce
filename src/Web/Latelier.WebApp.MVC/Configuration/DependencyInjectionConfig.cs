using Latelier.WebApp.MVC.Extensions;
using Latelier.WebApp.MVC.Services;
using Latelier.WebApp.MVC.Services.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Latelier.WebApp.MVC.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

			services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

			//services.AddHttpClient<ICatalogoService, CatalogoService>()
			//	.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

			services.AddHttpClient(name: "Refit",
				configureClient: options =>
				{
					options.BaseAddress = new Uri(configuration.GetSection(key: "CatalogoUrl").Value);
				})
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddScoped<IUser, AspNetUser>();
		}
	}
}
