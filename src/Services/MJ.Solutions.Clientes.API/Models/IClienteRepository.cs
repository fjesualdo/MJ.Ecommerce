﻿using MJ.Solutions.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MJ.Solutions.Clientes.API.Models
{
	public interface IClienteRepository : IRepository<Cliente>
	{
		void Adicionar(Cliente cliente);

		Task<IEnumerable<Cliente>> ObterTodos();

		Task<Cliente> ObterPorCpf(string cpf);

		void AdicionarEndereco(Endereco endereco);

		Task<Endereco> ObterEnderecoPorId(Guid id);
	}
}
