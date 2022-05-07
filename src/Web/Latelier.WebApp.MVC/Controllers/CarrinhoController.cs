﻿using Latelier.WebApp.MVC.Models;
using Latelier.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Controllers
{
	public class CarrinhoController : MainController
	{

		private readonly IComprasBFFService _comprasBFFService;

		public CarrinhoController(IComprasBFFService comprasBFFService)
		{
			_comprasBFFService = comprasBFFService;
		}

		[Route("carrinho")]
		public async Task<IActionResult> Index()
		{
			return View(await _comprasBFFService.ObterCarrinho());
		}

		[HttpPost]
		[Route("carrinho/adicionar-item")]
		public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinhoViewModel itemCarrinho)
		{
			var resposta = await _comprasBFFService.AdicionarItemCarrinho(itemCarrinho);

			if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBFFService.ObterCarrinho());

			return RedirectToAction("Index");
		}

		[HttpPost]
		[Route("carrinho/atualizar-item")]
		public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
		{
			var item = new ItemCarrinhoViewModel { ProdutoId = produtoId, Quantidade = quantidade };
			var resposta = await _comprasBFFService.AtualizarItemCarrinho(produtoId, item);

			if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBFFService.ObterCarrinho());

			return RedirectToAction("Index");
		}

		[HttpPost]
		[Route("carrinho/remover-item")]
		public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
		{
			var resposta = await _comprasBFFService.RemoverItemCarrinho(produtoId);

			if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBFFService.ObterCarrinho());

			return RedirectToAction("Index");
		}

		[HttpPost]
		[Route("carrinho/aplicar-voucher")]
		public async Task<IActionResult> AplicarVoucher(string voucherCodigo)
		{
			var resposta = await _comprasBFFService.AplicarVoucherCarrinho(voucherCodigo);

			if (ResponsePossuiErros(resposta)) return View("Index", await _comprasBFFService.ObterCarrinho());

			return RedirectToAction("Index");
		}
	}
}
