using Microsoft.AspNetCore.Mvc;

namespace MJ.Solutions.Pedido.API.Controllers
{
	public class PedidoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
