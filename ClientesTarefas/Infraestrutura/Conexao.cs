using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Infraestrutura
{
	public class Conexao : IConexao

	{
		public SqlConnection RetornaConexao()
		{
			return new SqlConnection(@"Data Source=mat019\sqlexpress;" +
			   "Initial Catalog=CLIENTE_TAREFA;Integrated Security=SSPI;");
		}
	}
}
