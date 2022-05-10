using Latelier.WebApp.MVC.Models;
using Latelier.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Controllers
{
	public class PedidoController : MainController
	{
		private readonly IClienteService _clienteService;
		private readonly IComprasBFFService _comprasBFFService;

		public PedidoController(IClienteService clienteService, IComprasBFFService comprasBffService)
		{
			_clienteService = clienteService;
			_comprasBFFService = comprasBffService;
		}

		[HttpGet]
		[Route("endereco-de-entrega")]
		public async Task<IActionResult> EnderecoEntrega()
		{
			var carrinho = await _comprasBFFService.ObterCarrinho();
			if (carrinho.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

			var endereco = await _clienteService.ObterEndereco();
			var pedido = _comprasBFFService.MapearParaPedido(carrinho, endereco);

			return View(pedido);
		}

		[HttpGet]
		[Route("pagamento")]
		public async Task<IActionResult> Pagamento()
		{
			var carrinho = await _comprasBFFService.ObterCarrinho();
			if (carrinho.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

			var pedido = _comprasBFFService.MapearParaPedido(carrinho, null);

			return View(pedido);
		}

		[HttpPost]
		[Route("finalizar-pedido")]
		public async Task<IActionResult> FinalizarPedido(PedidoTransacaoViewModel pedidoTransacao)
		{
			if (!ModelState.IsValid) return View("Pagamento", _comprasBFFService.MapearParaPedido(
					await _comprasBFFService.ObterCarrinho(), null));

			var retorno = await _comprasBFFService.FinalizarPedido(pedidoTransacao);

			if (ResponsePossuiErros(retorno))
			{
				var carrinho = await _comprasBFFService.ObterCarrinho();
				if (carrinho.Itens.Count == 0) return RedirectToAction("Index", "Carrinho");

				var pedidoMap = _comprasBFFService.MapearParaPedido(carrinho, null);
				return View("Pagamento", pedidoMap);
			}

			return RedirectToAction("PedidoConcluido");
		}

		[HttpGet]
		[Route("pedido-concluido")]
		public async Task<IActionResult> PedidoConcluido()
		{
			return View("ConfirmacaoPedido", await _comprasBFFService.ObterUltimoPedido());
		}

		[HttpGet("meus-pedidos")]
		public async Task<IActionResult> MeusPedidos()
		{
			return View(await _comprasBFFService.ObterListaPorClienteId());
		}
	}
}
