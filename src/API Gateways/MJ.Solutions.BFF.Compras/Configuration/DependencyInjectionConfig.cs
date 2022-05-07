﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.BFF.Compras.Extensions;
using MJ.Solutions.BFF.Compras.Services;
using MJ.Solutions.WebAPI.Core.Extensions;
using MJ.Solutions.WebAPI.Core.Usuario;
using Polly;
using System;

namespace MJ.Solutions.BFF.Compras.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();

			services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

			services.AddHttpClient<ICatalogoService, CatalogoService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

			services.AddHttpClient<ICarrinhoService, CarrinhoService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

			services.AddHttpClient<IPedidoService, PedidoService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
		}
	}
}
