using Microsoft.Extensions.Options;
using MJ.Solutions.BFF.Compras.Extensions;
using System;
using System.Net.Http;

namespace MJ.Solutions.BFF.Compras.Services
{
	public class CatalogoService : Service, ICatalogoService
	{
		private readonly HttpClient _httpClient;

		public CatalogoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
		}
	}
}
