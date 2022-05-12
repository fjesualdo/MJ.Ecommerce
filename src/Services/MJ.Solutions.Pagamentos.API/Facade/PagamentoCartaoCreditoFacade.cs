﻿using Microsoft.Extensions.Options;
using MJ.Solutions.Pagamentos.API.Models;
using MJ.Solutions.Pagamentos.MJPag;
using System;
using System.Threading.Tasks;

namespace MJ.Solutions.Pagamentos.API.Facade
{
	public class PagamentoCartaoCreditoFacade : IPagamentoFacade
	{
		private readonly PagamentoConfig _pagamentoConfig;

		public PagamentoCartaoCreditoFacade(IOptions<PagamentoConfig> pagamentoConfig)
		{
			_pagamentoConfig = pagamentoConfig.Value;
		}

		public async Task<Transacao> AutorizarPagamento(Pagamento pagamento)
		{
			var nerdsPagSvc = new MJPagService(_pagamentoConfig.DefaultApiKey, _pagamentoConfig.DefaultEncryptionKey);

			var cardHashGen = new CardHash(nerdsPagSvc)
			{
				CardNumber = pagamento.CartaoCredito.NumeroCartao,
				CardHolderName = pagamento.CartaoCredito.NomeCartao,
				CardExpirationDate = pagamento.CartaoCredito.MesAnoVencimento,
				CardCvv = pagamento.CartaoCredito.CVV
			};

			var cardHash = cardHashGen.Generate();

			var transacao = new Transaction(nerdsPagSvc)
			{
				CardHash = cardHash,
				CardNumber = pagamento.CartaoCredito.NumeroCartao,
				CardHolderName = pagamento.CartaoCredito.NomeCartao,
				CardExpirationDate = pagamento.CartaoCredito.MesAnoVencimento,
				CardCvv = pagamento.CartaoCredito.CVV,
				PaymentMethod = PaymentMethod.CreditCard,
				Amount = pagamento.Valor
			};

			return ParaTransacao(await transacao.AuthorizeCardTransaction());
		}

		public static Transacao ParaTransacao(Transaction transaction)
		{
			return new Transacao
			{
				Id = Guid.NewGuid(),
				Status = (StatusTransacao)transaction.Status,
				ValorTotal = transaction.Amount,
				BandeiraCartao = transaction.CardBrand,
				CodigoAutorizacao = transaction.AuthorizationCode,
				CustoTransacao = transaction.Cost,
				DataTransacao = transaction.TransactionDate,
				NSU = transaction.Nsu,
				TID = transaction.Tid
			};
		}
	}
}
