using System.Collections.Generic;
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
		
		public async Task<IEnumerable<RelatorioCliente>> BuscarTodosClientesETarefasAsync()
		{
			var relatorio = await _relatorioRepositorio.BuscarTodosClientesETarefasAsync();


			return relatorio;
		}
	}
}
