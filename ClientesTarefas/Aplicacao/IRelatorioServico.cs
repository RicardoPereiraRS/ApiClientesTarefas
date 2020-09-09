using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio;

namespace Aplicacao
{
	public interface IRelatorioServico
	{
		Task<IEnumerable<RelatorioClienteModel>> BuscarTodosClientesETarefasAsync();
	}
}
