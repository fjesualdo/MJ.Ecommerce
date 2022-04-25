using Microsoft.AspNetCore.Mvc;
using MJ.Solutions.Clientes.API.Application.Commands;
using MJ.Solutions.Core.Mediator;
using MJ.Solutions.WebAPI.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace MJ.Solutions.Clientes.API.Controllers
{
	public class ClientesController : MainController
	{
		private readonly IMediatorHandler _mediatorHanddler;

		public ClientesController(IMediatorHandler mediatorHanddler)
		{
			_mediatorHanddler = mediatorHanddler;
		}


		[HttpGet("clientes")]
		public async Task<IActionResult> Index()
		{
			var resultado = await _mediatorHanddler.EnviarComando(new RegistrarClienteCommand(Guid.NewGuid(), "Marcelo", "fjesualdo@gmail.com", "05336153729"));

			return CustomResponse(resultado);
		}
	}
}
