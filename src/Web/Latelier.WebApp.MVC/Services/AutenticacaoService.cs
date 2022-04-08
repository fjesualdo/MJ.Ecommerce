using Latelier.WebApp.MVC.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Services
{
	public class AutenticacaoService : Service, IAutenticacaoService
	{
		private readonly HttpClient _httpClient;

		public AutenticacaoService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
		{
			var loginContent = ObterConteudo(usuarioLogin);

			var response = await _httpClient.PostAsync(requestUri: "https://localhost:44384/api/identidade/autenticar/", content: loginContent);

			if (!TratarErrosResponse(response))
			{
				return new UsuarioRespostaLogin
				{
					ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
				};
			};

			return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
		}

		public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
		{
			var registroContent = ObterConteudo(usuarioRegistro);

			var response = await _httpClient.PostAsync(requestUri: "https://localhost:44384/api/identidade/nova-conta/", content: registroContent);

			if (!TratarErrosResponse(response))
			{
				return new UsuarioRespostaLogin
				{
					ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
				};
			}

			return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
		}
	}
}
