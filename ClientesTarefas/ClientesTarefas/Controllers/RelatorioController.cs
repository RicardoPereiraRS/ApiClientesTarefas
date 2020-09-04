using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplicacao;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class RelatorioController : ControllerBase
	{
		private ITarefaServico _tarefaServico;

		private IRelatorioServico _relatorioServico;

		public RelatorioController(ITarefaServico tarefaServico, IRelatorioServico relatorioServico)
		{
			_tarefaServico = tarefaServico;

			_relatorioServico = relatorioServico;
		}

		// Lista todos os clientes e suas tarefas
		[HttpGet]
		public async Task<IEnumerable<RelatorioModel>> GetRelatorioAsync()
		{
			return await _relatorioServico.BuscarTodosClientesETarefasAsync();
		}

	}
}
