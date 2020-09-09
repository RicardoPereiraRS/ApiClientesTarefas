using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao;
using Microsoft.AspNetCore.Mvc;



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
		public  async Task<IEnumerable<RelatorioClienteModel>> GetRelatorioAsync()
		{

		
			return await  _relatorioServico.BuscarTodosClientesETarefasAsync();
		
		
		}

	}
}
