﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MJ.Solutions.Catalogo.API.Models;
using MJ.Solutions.WebAPI.Core.Identidade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MJ.Solutions.Catalogo.API.Controllers
{
	[ApiController]
	[Authorize]
	public class CatalogoController : Controller
	{
		private readonly IProdutoRepository _produtoRepository;

		public CatalogoController(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		[AllowAnonymous]
		[HttpGet("catalogo/produtos")]
		public async Task<IEnumerable<Produto>> Index()
		{
			return await _produtoRepository.ObterTodos();
		}

		[ClaimsAuthorize("Catalogo", "Ler")]
		[HttpGet("catalogo/produtos/{id}")]
		public async Task<Produto> ProdutoDetalhe(Guid id)
		{
			throw new Exception("JESUALDO JESUALDO JESUALDO JESUALDO JESUALDO ----------->>>>>>>>>>>>>>>>> Erro!");
			return await _produtoRepository.ObterPorId(id);
		}
	}
}
