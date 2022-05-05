using Latelier.WebApp.MVC.Models;
using Latelier.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.ViewComponents
{
	public class CarrinhoViewComponent : ViewComponent
	{
		private readonly IComprasBFFService _comprasBFFService;

		public CarrinhoViewComponent(IComprasBFFService comprasBFFService)
		{
			_comprasBFFService = comprasBFFService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await _comprasBFFService.ObterQuantidadeCarrinho());
		}
	}
}
