using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Infraestrutura
{
	public interface IRelatorioRepositorio
	{
		public Task<IEnumerable<Relatorio>> BuscarTodosClientesETarefasAsync();
	}
}
