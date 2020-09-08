using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dominio;

namespace Infraestrutura
{
	public class ClienteRepositorio : IClienteRepositorio

	{
		private IConexao _conexao;

		public ClienteRepositorio(IConexao conexao)
		{
			_conexao = conexao;
		}

		public async Task<int> IncluirClienteAsync(string nome)
		{
			using (SqlConnection cn = _conexao.RetornaConexao())
			{
				try
				{
					var id = await cn.QuerySingleAsync<int>
						("INSERT INTO CLIENTE (NOME) VALUES (@nome);" +
						"SELECT CAST(SCOPE_IDENTITY() as int)", new { nome });

					return id;
				}
				catch (Exception)
				{

					throw new Exception("Não foi possível incluir o Cliente.");
				}
			}
		}

		public async Task<Cliente> BuscarClienteAsync(int id)
		{
			{
				using (SqlConnection connection = _conexao.RetornaConexao())
				{
					var clienteDominio = await connection.QueryFirstOrDefaultAsync
						<Cliente>("SELECT ID,NOME FROM CLIENTE WHERE ID=@id", new { id });

					return clienteDominio;
				}
			}
		}
		public async Task<bool> ClientJaCadastradoAsync(string nome)
		{
			{
				using (SqlConnection connection = _conexao.RetornaConexao())
				{
					int cadastrado = await connection.QuerySingleAsync
						<int>("SELECT COUNT(*) FROM CLIENTE WHERE NOME=@nome", new { nome });

					return cadastrado > 0;
				}
			}
		}
		public async Task<IEnumerable<Cliente>> BuscarTodosClientesAsync()
		{
			using (var connection = _conexao.RetornaConexao())
			{
				var clienteDomio = await connection.QueryAsync<Cliente>
					("SELECT ID,NOME FROM CLIENTE");

				return clienteDomio.ToList();
			}
		}
	}
}
