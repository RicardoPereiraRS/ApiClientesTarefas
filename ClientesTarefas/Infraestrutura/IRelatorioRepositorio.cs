using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio;

namespace Infraestrutura
{
	public interface IRelatorioRepositorio
	{
		public Task<IEnumerable<RelatorioCliente>> BuscarTodosClientesETarefasAsync();
	}
}
