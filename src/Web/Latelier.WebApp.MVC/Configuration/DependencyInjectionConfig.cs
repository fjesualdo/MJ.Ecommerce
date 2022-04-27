using Latelier.WebApp.MVC.Extensions;
using Latelier.WebApp.MVC.Services;
using Latelier.WebApp.MVC.Services.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.WebAPI.Core.Usuario;
using Polly;
using System;

namespace Latelier.WebApp.MVC.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();

			services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

			services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

			services.AddHttpClient<ICatalogoService, CatalogoService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				//.AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: _ => TimeSpan.FromMilliseconds(600)));
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 5, durationOfBreak: TimeSpan.FromSeconds(30)));


			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();

			#region Refit
			//services.AddHttpClient(name: "Refit",
			//	configureClient: options =>
			//	{
			//		options.BaseAddress = new Uri(configuration.GetSection(key: "CatalogoUrl").Value);
			//	})
			//	.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
			//	.AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);
			#endregion
		}
	}
}
