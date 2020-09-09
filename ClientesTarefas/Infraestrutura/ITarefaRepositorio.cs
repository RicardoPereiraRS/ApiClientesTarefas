using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Dominio;
namespace Infraestrutura
{
	public interface ITarefaRepositorio
	{
		public Task<int> IncluirTarefaAsync(int id,DateTime data, string descricao);

		public Task<IEnumerable<Tarefa>> BuscarTodasTarefasClientesAsync(int id);

		public Task<IEnumerable<Tarefa>> BuscarTarefasContendoEDataMaiorAsync();
	}
}
