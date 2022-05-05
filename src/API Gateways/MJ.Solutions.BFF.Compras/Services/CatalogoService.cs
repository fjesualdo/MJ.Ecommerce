using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using MJ.Solutions.BFF.Compras.Extensions;

namespace MJ.Solutions.BFF.Compras.Services
{
  public interface ICatalogoService
  {
  }

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
