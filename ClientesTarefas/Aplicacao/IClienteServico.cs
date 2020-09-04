using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
	public interface IClienteServico
	{
		public Task<IEnumerable<ClienteModel>> BuscarTodosClientesAsync();
		public Task<ClienteModel> BuscarClienteAsync(int id);
		public Task<ClienteModel> IncluirClienteAsync(string nome);
	}
}
