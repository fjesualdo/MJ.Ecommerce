﻿using MJ.Solutions.Core.Specification;
using System;
using System.Linq.Expressions;

namespace MJ.Solutions.Pedidos.Domain.Specs
{
	public class VoucherDataSpecification : Specification<Voucher>
	{
		public override Expression<Func<Voucher, bool>> ToExpression()
		{
			return voucher => voucher.DataValidade >= DateTime.Now;
		}
	}

	public class VoucherQuantidadeSpecification : Specification<Voucher>
	{
		public override Expression<Func<Voucher, bool>> ToExpression()
		{
			return voucher => voucher.Quantidade > 0;
		}
	}

	public class VoucherAtivoSpecification : Specification<Voucher>
	{
		public override Expression<Func<Voucher, bool>> ToExpression()
		{
			return voucher => voucher.Ativo && !voucher.Utilizado;
		}
	}
}
