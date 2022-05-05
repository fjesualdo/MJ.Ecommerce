using Latelier.WebApp.MVC.Models;
using Latelier.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Extensions
{
	public class CarrinhoViewComponent : ViewComponent
	{
		private readonly ICarrinhoService _carrinhoService;

		public CarrinhoViewComponent(ICarrinhoService carrinhoService)
		{
			_carrinhoService = carrinhoService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await _carrinhoService.ObterCarrinho() ?? new CarrinhoViewModel());
		}
	}
}
