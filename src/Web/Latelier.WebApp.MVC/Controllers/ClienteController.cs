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
  }
}
