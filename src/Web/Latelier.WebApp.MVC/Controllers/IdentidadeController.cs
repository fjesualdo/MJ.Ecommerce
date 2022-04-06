using Latelier.WebApp.MVC.Models;
using Latelier.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Controllers
{
	public class IdentidadeController : Controller
	{
		private readonly IAutenticacaoService _autenticacaoService;

		public IdentidadeController(IAutenticacaoService autenticacaoService)
		{
			_autenticacaoService = autenticacaoService;
		}

		[HttpGet]
		[Route("nova-conta")]
		public IActionResult Registro()
		{
			return View();
		}

		[HttpPost]
		[Route("nova-conta")]
		public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
		{
			if (!ModelState.IsValid) return View(usuarioRegistro);

			// API - Login

			var resposta = await _autenticacaoService.Registro(usuarioRegistro);

			// Realizar login na APP

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[Route("login")]
		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
		{
			if (!ModelState.IsValid) return View(usuarioLogin);

			// API - Login

			var resposta = await _autenticacaoService.Login(usuarioLogin);

			// Realizar login na APP

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[Route("sair")]
		public async Task<IActionResult> Logout()
		{
			return RedirectToAction("Index", "Home");
		}
	}
}
