using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dominio;

namespace Infraestrutura
{
	public class RelatorioRepositorio : IRelatorioRepositorio
	{
		private IConexao _conexao;

		public RelatorioRepositorio(IConexao conexao)
		{
			_conexao = conexao;
		}

		public async Task<IEnumerable<RelatorioCliente>> BuscarTodosClientesETarefasAsync()
		{
			using (var connection = _conexao.RetornaConexao())
			{
				string sq = "SELECT c.ID as Id,c.NOME as Nome," +
					"t.ID as IdTarefa, t.DESCRICAO " +
					"FROM CLIENTE c " +
					"INNER JOIN TAREFA t " +
					"ON c.id = t.ID_CLIENTE";

				var relatorioClienteDictionary = new Dictionary<int, RelatorioCliente>();

				var list = await connection.QueryAsync<RelatorioCliente, RelatorioTarefa, RelatorioCliente>(
					sq,
					(relatorioCliente, relatorioTarefa) =>
					{
						RelatorioCliente entry;

						if (!relatorioClienteDictionary.TryGetValue(relatorioCliente.Id, out entry))
						{
							entry = relatorioCliente;
							entry.Tarefas = new List<RelatorioTarefa>();
							relatorioClienteDictionary.Add(entry.Id, entry);
						}

						entry.Tarefas.Add(relatorioTarefa);
						return entry;
					},

					   splitOn: "IdTarefa");

				return list.Distinct();

			}
		}
	}
}
