using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MJ.Solutions.BFF.Compras.Extensions;
using MJ.Solutions.BFF.Compras.Models;

namespace MJ.Solutions.BFF.Compras.Services
{
	public class PedidoService : Service, IPedidoService
  {
    private readonly HttpClient _httpClient;

    public PedidoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
    {
      _httpClient = httpClient;
      _httpClient.BaseAddress = new Uri(settings.Value.PedidoUrl);
    }

    public async Task<VoucherDTO> ObterVoucherPorCodigo(string codigo)
    {
      var response = await _httpClient.GetAsync($"/voucher/{codigo}/");

      if (response.StatusCode == HttpStatusCode.NotFound) return null;

      TratarErrosResponse(response);

      return await DeserializarObjetoResponse<VoucherDTO>(response);
    }

  }
}
