﻿using Latelier.WebApp.MVC.Extensions;
using Latelier.WebApp.MVC.Services;
using Latelier.WebApp.MVC.Services.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.WebAPI.Core.Usuario;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Net.Http;

namespace Latelier.WebApp.MVC.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();

			#region HttpServices

			services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

			services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 5, durationOfBreak: TimeSpan.FromSeconds(30)));

			services.AddHttpClient<ICatalogoService, CatalogoService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 5, durationOfBreak: TimeSpan.FromSeconds(30)));

			services.AddHttpClient<IComprasBFFService, ComprasBFFService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 5, durationOfBreak: TimeSpan.FromSeconds(30)));

			#endregion HttpServices
		}
	}

	#region PollyExtension

	public static class PollyExtensions
	{
		public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
		{
			var retry = HttpPolicyExtensions
					.HandleTransientHttpError()
					.WaitAndRetryAsync(new[]
					{
										TimeSpan.FromSeconds(1),
										TimeSpan.FromSeconds(5),
										TimeSpan.FromSeconds(10),
					}, (outcome, timespan, retryCount, context) =>
					{
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.WriteLine($"Tentando pela {retryCount} vez!");
						Console.ForegroundColor = ConsoleColor.White;
					});

			return retry;
		}
	}

	#endregion
}