using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
	public interface IRelatorioServico
	{
		Task<IEnumerable<RelatorioModel>> BuscarTodosClientesETarefasAsync();
	}
}
