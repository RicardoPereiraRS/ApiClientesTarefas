using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura
{
	public interface IConexao
	{
		SqlConnection RetornaConexao();
	}
}
