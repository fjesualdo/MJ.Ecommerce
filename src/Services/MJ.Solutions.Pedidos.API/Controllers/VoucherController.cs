﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MJ.Solutions.Pedidos.API.Application.DTO;
using MJ.Solutions.Pedidos.API.Application.Queries;
using MJ.Solutions.WebAPI.Core.Controllers;
using System.Net;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedidos.API.Controllers

{
  [Authorize]
  public class VoucherController : MainController
	{
    private readonly IVoucherQueries _voucherQueries;

    public VoucherController(IVoucherQueries voucherQueries)
    {
      _voucherQueries = voucherQueries;
    }

    [HttpGet("voucher/{codigo}")]
    [ProducesResponseType(typeof(VoucherDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> ObterPorCodigo(string codigo)
    {
      if (string.IsNullOrEmpty(codigo)) return NotFound();

      var voucher = await _voucherQueries.ObterVoucherPorCodigo(codigo);

      return voucher == null ? NotFound() : CustomResponse(voucher);
    }
  }
}
