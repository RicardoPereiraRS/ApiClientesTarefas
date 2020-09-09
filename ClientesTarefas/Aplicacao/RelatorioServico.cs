using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Infraestrutura;

namespace Aplicacao
{
	public class RelatorioServico : IRelatorioServico
	{
		IRelatorioRepositorio _relatorioRepositorio;
		public RelatorioServico(IRelatorioRepositorio relatorioRepositorio)
		{
			_relatorioRepositorio = relatorioRepositorio;
		}

		public async Task<IEnumerable<RelatorioClienteModel>> BuscarTodosClientesETarefasAsync()
		{
			var relatorioClienteDominio = await _relatorioRepositorio.BuscarTodosClientesETarefasAsync();

			List<RelatorioClienteModel> relatorio = new List<RelatorioClienteModel>();

			foreach (RelatorioCliente item in relatorioClienteDominio)
			{

				List<RelatorioTarefaModel> tarefas = new List<RelatorioTarefaModel>();

				foreach (RelatorioTarefa itemTarefa in item.Tarefas)
				{
					tarefas.Add(new RelatorioTarefaModel
					{
						IdTarefa = itemTarefa.IdTarefa,

						DataCriacao = itemTarefa.DataCriacao,

						Descricao = itemTarefa.Descricao
					});
				}

				relatorio.Add(new RelatorioClienteModel { Id = item.Id, Nome = item.Nome, Tarefas = tarefas });
			}

			return relatorio;
		}
	}
}
