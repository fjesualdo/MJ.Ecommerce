﻿using Latelier.WebApp.MVC.Extensions;
using Latelier.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using MJ.Solutions.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Services
{
	public class ComprasBFFService : Service, IComprasBFFService
	{
		private readonly HttpClient _httpClient;

		public ComprasBFFService(HttpClient httpClient, IOptions<AppSettings> settings)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(settings.Value.ComprasBFFUrl);
		}

		#region Carrinho
		public async Task<CarrinhoViewModel> ObterCarrinho()
		{
			var response = await _httpClient.GetAsync("/compras/carrinho/");

			TratarErrosResponse(response);

			return await DeserializarObjetoResponse<CarrinhoViewModel>(response);
		}

		public async Task<int> ObterQuantidadeCarrinho()
		{
			var response = await _httpClient.GetAsync("/compras/carrinho-quantidade/");

			TratarErrosResponse(response);

			return await DeserializarObjetoResponse<int>(response);
		}

		public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel carrinho)
		{
			var itemContent = ObterConteudo(carrinho);

			var response = await _httpClient.PostAsync("/compras/carrinho/items/", itemContent);

			if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

			return RetornoOk();
		}

		public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel item)
		{
			var itemContent = ObterConteudo(item);

			var response = await _httpClient.PutAsync($"/compras/carrinho/items/{produtoId}", itemContent);

			if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

			return RetornoOk();
		}

		public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
		{
			var response = await _httpClient.DeleteAsync($"/compras/carrinho/items/{produtoId}");

			if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

			return RetornoOk();
		}

		public async Task<ResponseResult> AplicarVoucherCarrinho(string voucher)
		{
			var itemContent = ObterConteudo(voucher);

			var response = await _httpClient.PostAsync("/compras/carrinho/aplicar-voucher/", itemContent);

			if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

			return RetornoOk();
		}
		#endregion
	}
}
