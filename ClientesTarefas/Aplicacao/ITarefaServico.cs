using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao
{
	public interface ITarefaServico
	{
		public Task<TarefaModel> IncluirTarefaAsync(int id, string descricao);
		public Task<IEnumerable<TarefaModel>> BuscarTodasTarefasClientesAsync(int id);
	}
}
