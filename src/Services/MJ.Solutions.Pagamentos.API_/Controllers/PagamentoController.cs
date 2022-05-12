using Microsoft.AspNetCore.Mvc;

namespace MJ.Solutions.Pagamentos.API.Controllers
{
	public class PagamentoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
