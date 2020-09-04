using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Infraestrutura
{
	public interface ITarefaRepositorio
	{
		public Task<int>IncluirTarefaAsync(int id, string descricao);

		public Task<IEnumerable<Tarefa>> BuscarTodasTarefasClientesAsync(int id);
	}
}
