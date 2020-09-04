using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dominio;


namespace Infraestrutura
{
	public interface IClienteRepositorio
	{
		public Task<int> IncluirClienteAsync(string nome);

		public Task<IEnumerable<Cliente>> BuscarTodosClientesAsync();

		public Task<Cliente> BuscarClienteAsync(int id);

		public  Task<bool> ClientJaCadastradoAsync(string nome);

	}
}
