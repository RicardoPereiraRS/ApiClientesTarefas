using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplicacao;
using Dominio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class RelatorioController : ControllerBase
	{

		private IRelatorioServico _relatorioServico;

		public RelatorioController(IRelatorioServico relatorioServico)
		{

			_relatorioServico = relatorioServico;
		}

		// Lista todos os clientes e suas tarefas
		[HttpGet]
		public  async Task<IEnumerable<RelatorioCliente>> GetRelatorioAsync()
		{
		
			return await _relatorioServico.BuscarTodosClientesETarefasAsync();
		
		
		}

	}
}
