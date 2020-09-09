using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TarefasController : ControllerBase
	{
		private ITarefaServico _tarefaServico;

		public TarefasController(ITarefaServico tarefaServico)
		{
			_tarefaServico = tarefaServico;
		}


		// Busca todas as tarefas de um cliente.
		[HttpGet("{id}")]
		public async Task<IEnumerable<TarefaModel>> GetTarefasAsync(int id)
		{
			return await _tarefaServico.BuscarTodasTarefasClientesAsync(id);
		}
		[HttpGet]
		public async Task<IEnumerable<TarefaModel>> GetTarefasAsync(string contem, string dataMaiorQue)
		{

			return await _tarefaServico.BuscarTarefasContendoEDataMaiorAsync(contem, dataMaiorQue);
		}

		// Inclui uma tarefa para um cliente cadastrado.
		[HttpPost("{id}")]

		public async Task<TarefaModel> InccluirTarefaAsync(int id, [FromBody] TarefaModel tarefa)
		{
			return await _tarefaServico.IncluirTarefaAsync(id, tarefa.DataCriacao, tarefa.Descricao);
		}

	}
}
