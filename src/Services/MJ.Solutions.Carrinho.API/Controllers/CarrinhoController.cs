using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MJ.Solutions.Carrinho.API.Data;
using MJ.Solutions.Carrinho.API.Model;
using MJ.Solutions.WebAPI.Core.Controllers;
using MJ.Solutions.WebAPI.Core.Usuario;
using System;
using System.Threading.Tasks;

namespace MJ.Solutions.Carrinho.API.Controllers
{
	[Authorize]
	public class CarrinhoController : MainController
	{
		private readonly IAspNetUser _user;
		public CarrinhoController(IAspNetUser user)
		{
			_user = user;
		}

		[HttpGet("carrinho")]
		public async Task<CarrinhoCliente> ObterCarrinho()
		{
			return null;
		}

		[HttpPost("carrinho")]
		public async Task<IActionResult> AdicionarItemCarrinho(CarrinhoItem item)
		{
			return CustomResponse();
		}

		[HttpPut("carrinho/{produtoId}")]
		public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, CarrinhoItem item)
		{
			return CustomResponse();
		}

		[HttpDelete("carrinho/{produtoId}")]
		public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
		{
			return CustomResponse();
		}
	}
}
