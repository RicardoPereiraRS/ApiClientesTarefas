using System;
using System.Collections.Generic;
using System.Text;
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
		
		public async Task<IEnumerable<RelatorioModel>> BuscarTodosClientesETarefasAsync()
		{
			var relatorioDominio = await _relatorioRepositorio.BuscarTodosClientesETarefasAsync();

			List<RelatorioModel> relatorioModel = new List<RelatorioModel>();

		

			foreach (Relatorio relatorio in relatorioDominio)
			{
				relatorioModel.Add(new RelatorioModel
				{
					Id = relatorio.Id,
					IdCliente = relatorio.IdCliente,
					Nome = relatorio.Nome,
					DescricaoTarefa = relatorio.DescricaoTarefa
				});
			}

			// retorna null se não encontra dados
			if (relatorioModel.Count == 0)
			{
				return null;
			}

			return relatorioModel;
		}
	}
}
