using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Infraestrutura;
using Dominio;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data;

namespace Aplicacao
{
	public class ClienteServico : IClienteServico
	{
		IClienteRepositorio _clienteRepositorio;
		public ClienteServico(IClienteRepositorio clienteRepositorio)
		{
			_clienteRepositorio = clienteRepositorio;
		}

		public async Task<IEnumerable<ClienteModel>> BuscarTodosClientesAsync()
		{
			var clienteDominio = await _clienteRepositorio.BuscarTodosClientesAsync();

			List<ClienteModel> clienteModel = new List<ClienteModel>();


			foreach (Cliente cliente in clienteDominio)
			{
				clienteModel.Add(new ClienteModel { Id = cliente.Id, Nome = cliente.Nome });
			}

			//retorna null se não encontra dados
			if (clienteModel.Count == 0)
			{
				return null;
			}

			return clienteModel;
		}

		public async Task<ClienteModel> BuscarClienteAsync(int id)
		{
			var clienteDominio = await _clienteRepositorio.BuscarClienteAsync(id);

			// retorna null se não encontra dados
			if (clienteDominio == null)
			{
				return null;
			}

			return new ClienteModel
			{
				Id = clienteDominio.Id,
				Nome = clienteDominio.Nome
			};
		}

		public async Task<ClienteModel> IncluirClienteAsync(string nome)
		{
			if (!ClienteModel.NomeClienteaValido(nome))
			{
				throw new Exception("O Parâmetro nome é inválido.");
			}

			nome = ClienteModel.LimitarTamanhoNomeCliente(nome);

			if (await _clienteRepositorio.ClientJaCadastradoAsync(nome))
			{
				throw new Exception("Este Cliente já está cadastrado.");
			}


			int id = await _clienteRepositorio.IncluirClienteAsync(nome);

			return new ClienteModel { Id = id, Nome = nome };
		}
	}
}
