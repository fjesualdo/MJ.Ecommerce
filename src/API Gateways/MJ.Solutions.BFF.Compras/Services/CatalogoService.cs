using Microsoft.Extensions.Options;
using MJ.Solutions.BFF.Compras.Extensions;
using MJ.Solutions.BFF.Compras.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

		public async Task<ItemProdutoDTO> ObterPorId(Guid id)
		{
			var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");

			TratarErrosResponse(response);

			return await DeserializarObjetoResponse<ItemProdutoDTO>(response);
		}
	}
}
