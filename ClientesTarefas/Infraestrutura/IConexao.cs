using System.Data.SqlClient;

namespace Infraestrutura
{
	public interface IConexao
	{
		SqlConnection RetornaConexao();
	}
}
