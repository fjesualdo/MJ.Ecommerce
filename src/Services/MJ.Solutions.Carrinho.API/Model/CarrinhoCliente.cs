using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace MJ.Solutions.Carrinho.API.Model
{
	public class CarrinhoCliente
	{
		internal const int MAX_QUANTIDADE_ITEM = 5;

		public Guid Id { get; set; }
		public Guid ClienteId { get; set; }
		public decimal ValorTotal { get; set; }
		public List<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();
		public ValidationResult ValidationResult { get; set; }

		public CarrinhoCliente() { }

		public CarrinhoCliente(Guid clienteId)
		{
			Id = Guid.NewGuid();
			ClienteId = clienteId;
		}
	}
}
