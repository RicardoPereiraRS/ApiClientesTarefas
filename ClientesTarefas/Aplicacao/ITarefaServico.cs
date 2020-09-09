using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao
{
	public interface ITarefaServico
	{
		public Task<TarefaModel> IncluirTarefaAsync(int id, DateTime data, string descricao);

		public Task<IEnumerable<TarefaModel>> BuscarTodasTarefasClientesAsync(int id);

		public Task<IEnumerable<TarefaModel>> BuscarTarefasContendoEDataMaiorAsync
			(string contem, string dataMaiorQue);
	}
}
