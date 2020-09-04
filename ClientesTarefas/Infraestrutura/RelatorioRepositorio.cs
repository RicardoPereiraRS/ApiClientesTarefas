using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		public async Task<IEnumerable<Relatorio>> BuscarTodosClientesETarefasAsync()
		{
			using (var connection = _conexao.RetornaConexao())
			{
				var relatorioDominio = await connection.QueryAsync<Relatorio>
					("SELECT t.ID,t.ID_CLIENTE AS idCliente,c.NOME," +
					"t.DESCRICAO as descricaoTarefa FROM CLIENTE c " +
					"INNER JOIN TAREFA t " +
					"ON c.id = t.ID_CLIENTE ORDER BY idCliente");

				return relatorioDominio.ToList();
			}
		}
	}
}
