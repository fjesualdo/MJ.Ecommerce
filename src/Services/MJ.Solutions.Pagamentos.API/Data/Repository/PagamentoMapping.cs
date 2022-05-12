﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MJ.Solutions.Pagamentos.API.Models;

namespace MJ.Solutions.Pagamentos.API.Data.Repository
{
	public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
	{
		public void Configure(EntityTypeBuilder<Pagamento> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Ignore(c => c.CartaoCredito);

			// 1 : N => Pagamento : Transacao
			builder.HasMany(c => c.Transacoes)
					.WithOne(c => c.Pagamento)
					.HasForeignKey(c => c.PagamentoId);

			builder.ToTable("Pagamentos");
		}
	}
}
