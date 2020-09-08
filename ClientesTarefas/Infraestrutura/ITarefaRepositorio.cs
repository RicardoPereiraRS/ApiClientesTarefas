using System.Collections.Generic;
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
