using FluentValidation.Results;
using MediatR;
using MJ.Solutions.Clientes.API.Application.Events;
using MJ.Solutions.Clientes.API.Models;
using MJ.Solutions.Core.Messaging;
using System.Threading;
using System.Threading.Tasks;


namespace MJ.Solutions.Clientes.API.Application.Commands
{
	public class ClienteCommandHandler : CommandHandler, 
																			 IRequestHandler<RegistrarClienteCommand, ValidationResult>,
																			 IRequestHandler<AdicionarEnderecoCommand, ValidationResult>
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteCommandHandler(IClienteRepository clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}

		public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid()) return message.ValidationResult;

			var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

			var clienteExistente = await _clienteRepository.ObterPorCpf(cliente.Cpf.Numero);

			if (clienteExistente != null)
			{
				AddError("Este CPF já está em uso.");
				return ValidationResult;
			}

			_clienteRepository.Adicionar(cliente);

			cliente.AddDomainEvent(new ClienteRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

			return await Commit(_clienteRepository.UnitOfWork);
		}

		public async Task<ValidationResult> Handle(AdicionarEnderecoCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid()) return message.ValidationResult;

			var endereco = new Endereco(message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.Cep, message.Cidade, message.Estado, message.ClienteId);
			_clienteRepository.AdicionarEndereco(endereco);

			return await Commit(_clienteRepository.UnitOfWork);
		}
	}
}