using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dominio;
namespace Infraestrutura
{
	public class TarefaRepositorio : ITarefaRepositorio
	{

		private IConexao _conexao;

		public TarefaRepositorio(IConexao conexao)
		{
			_conexao = conexao;
		}

		public async Task<IEnumerable<Tarefa>> BuscarTodasTarefasClientesAsync(int id)
		{
			using (var connection = _conexao.RetornaConexao())
			{

				var tarefaDominio = await connection.QueryAsync<Tarefa>
					("SELECT t.ID,t.ID_CLIENTE AS idCliente,c.NOME AS nomeCliente," +
					"t.descricao,t.data_criacao as dataCriacao FROM CLIENTE c " +
					"INNER JOIN TAREFA t " +
					"ON c.id = t.ID_CLIENTE " +
					"WHERE c.id=@id", new { id });

				return tarefaDominio.ToList();
			}
		}
		public async Task<IEnumerable<Tarefa>> BuscarTarefasContendoEDataMaiorAsync()
		{
			using (var connection = _conexao.RetornaConexao())
			{

				var tarefaDominio = await connection.QueryAsync<Tarefa>
					("SELECT t.ID,t.ID_CLIENTE AS idCliente,t.DATA_CRIACAO AS DataCriacao," +
					"c.NOME AS nomeCliente,t.descricao " +
					"FROM CLIENTE c " +
					"INNER JOIN TAREFA t " +
					"ON c.id = t.ID_CLIENTE ");

				return tarefaDominio.ToList();
			}
		}

		public async Task<int> IncluirTarefaAsync(int id, DateTime data, string descricao)
		{
			using (SqlConnection cn = _conexao.RetornaConexao())
			{
				try
				{
					int idInserido = await cn.QuerySingleAsync<int>
							("INSERT INTO TAREFA (ID_CLIENTE,DATA_CRIACAO,DESCRICAO)" +
							" VALUES (@id,@data,@descricao);" +
							"SELECT CAST(SCOPE_IDENTITY() as int)",
							 new { id, data, descricao });

					return idInserido;
				}
				catch (Exception)
				{

					throw new Exception("Não foi possível incluir a Tarefa.");
				}

			}
		}

	}
}
