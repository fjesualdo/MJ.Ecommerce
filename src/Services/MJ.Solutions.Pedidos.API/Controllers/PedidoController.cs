using Microsoft.AspNetCore.Mvc;

namespace MJ.Solutions.Pedidos.API.Controllers

{
	public class PedidoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
