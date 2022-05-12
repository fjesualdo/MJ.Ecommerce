using FluentValidation.Results;
using MediatR;
using MJ.Solutions.Core.Messaging;
using MJ.Solutions.MessageBus;
using MJ.Solutions.Pedidos.API.Application.DTO;
using MJ.Solutions.Pedidos.API.Application.Events;
using MJ.Solutions.Pedidos.Domain;
using MJ.Solutions.Pedidos.Domain.Pedidos;
using MJ.Solutions.Pedidos.Domain.Specs;
using MJ.Solutions.Pedidos.Integration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedidos.API.Application.Commands
{
	public class PedidoCommandHandler : CommandHandler, IRequestHandler<AdicionarPedidoCommand, ValidationResult>
	{
		private readonly IPedidoRepository _pedidoRepository;
		private readonly IVoucherRepository _voucherRepository;
		private readonly IMessageBus _bus;

		public PedidoCommandHandler(IVoucherRepository voucherRepository, IPedidoRepository pedidoRepository, IMessageBus bus)
		{
			_voucherRepository = voucherRepository;
			_pedidoRepository = pedidoRepository;
			_bus = bus;
		}

		public async Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
		{
			// Validarção do comando
			if (!message.IsValid()) return message.ValidationResult;

			// Mapear pedido
			var pedido = MapearPedido(message);

			// Aplicar voucher se houver
			if (!await AplicarVoucher(message, pedido)) return ValidationResult;

			// Validar pedido
			if (!ValidarPedido(pedido)) return ValidationResult;

			// Processar pagamento
			if (!await ProcessarPagamento(pedido, message)) return ValidationResult;

			// Se pagamento tudo OK!
			pedido.AutorizarPedido();

			// Adicionar Evento
			pedido.AddDomainEvent(new PedidoRealizadoEvent(pedido.Id, pedido.ClienteId));

			// Adicionar Pedido Repositorio
			_pedidoRepository.Adicionar(pedido);

			// Persistir dados de pedido e voucher
			return await Commit(_pedidoRepository.UnitOfWork);
		}

		private Pedido MapearPedido(AdicionarPedidoCommand message)
		{
			var endereco = new Endereco
			{
				Logradouro = message.Endereco.Logradouro,
				Numero = message.Endereco.Numero,
				Complemento = message.Endereco.Complemento,
				Bairro = message.Endereco.Bairro,
				Cep = message.Endereco.Cep,
				Cidade = message.Endereco.Cidade,
				Estado = message.Endereco.Estado
			};

			var pedido = new Pedido(message.ClienteId,
															message.ValorTotal,
															message.PedidoItems.Select(PedidoItemDTO.ParaPedidoItem).ToList(),
															message.VoucherUtilizado,
															message.Desconto);

			pedido.AtribuirEndereco(endereco);
			return pedido;
		}

		private async Task<bool> AplicarVoucher(AdicionarPedidoCommand message, Pedido pedido)
		{
			if (!message.VoucherUtilizado) return true;

			var voucher = await _voucherRepository.ObterVoucherPorCodigo(message.VoucherCodigo);
			if (voucher == null)
			{
				AddError("O voucher informado não existe!");
				return false;
			}

			var voucherValidation = new VoucherValidation().Validate(voucher);
			if (!voucherValidation.IsValid)
			{
				voucherValidation.Errors.ToList().ForEach(m => AddError(m.ErrorMessage));
				return false;
			}

			pedido.AtribuirVoucher(voucher);
			voucher.DebitarQuantidade();

			_voucherRepository.Atualizar(voucher);

			return true;
		}

		private bool ValidarPedido(Pedido pedido)
		{
			var pedidoValorOriginal = pedido.ValorTotal;
			var pedidoDesconto = pedido.Desconto;

			pedido.CalcularValorPedido();

			if (pedido.ValorTotal != pedidoValorOriginal)
			{
				AddError("O valor total do pedido não confere com o cálculo do pedido");
				return false;
			}

			if (pedido.Desconto != pedidoDesconto)
			{
				AddError("O valor total não confere com o cálculo do pedido");
				return false;
			}

			return true;
		}

		public async Task<bool> ProcessarPagamento(Pedido pedido, AdicionarPedidoCommand message)
		{
			var pedidoIniciado = new PedidoIniciadoIntegrationEvent
			{
				PedidoId = pedido.Id,
				ClienteId = pedido.ClienteId,
				Valor = pedido.ValorTotal,
				TipoPagamento = 1, // fixo. Alterar se tiver mais tipos
				NomeCartao = message.NomeCartao,
				NumeroCartao = message.NumeroCartao,
				MesAnoVencimento = message.ExpiracaoCartao,
				CVV = message.CVVCartao
			};

			var result = await _bus
					.RequestAsync<PedidoIniciadoIntegrationEvent, ResponseMessage>(pedidoIniciado);

			if (result.ValidationResult.IsValid) return true;

			foreach (var erro in result.ValidationResult.Errors)
			{
				AddError(erro.ErrorMessage);
			}

			return false;
		}

	}
}
