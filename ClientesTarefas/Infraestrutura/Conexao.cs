using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infraestrutura
{
	public class Conexao : IConexao

	{
		private IConfiguration _configuracao;

		public Conexao(IConfiguration configuracao)
		{
			_configuracao = configuracao;
		}

		public SqlConnection RetornaConexao()
		{
			string connString = _configuracao["ConnectionString"];

			return new SqlConnection(connString);
		}
	}
}
