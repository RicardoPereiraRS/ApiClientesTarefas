using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplicacao;
using System.Data.SqlClient;
using Infraestrutura;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientesTarefas.Controllers
{
	[Route("[controller]")]
	[ApiController]

	public class ClientesController : ControllerBase
	{
		private IClienteServico _clienteServico;

		private ITarefaServico _tarefaServico;

		private IRelatorioServico _relatorioServico;

		public ClientesController(IClienteServico clienteServico,
			ITarefaServico tarefaServico,IRelatorioServico relatorioServico)
		{
			_clienteServico = clienteServico;

			_tarefaServico = tarefaServico;

			_relatorioServico = relatorioServico;
		}

		// busca cliente por id
		[HttpGet("{id}")]
		public async Task<ClienteModel> GetAsync(int id)
		{
			return await _clienteServico.BuscarClienteAsync(id);
		}

		// Busca todos os clientes cadastrados.
		[HttpGet]
		public async Task<IEnumerable<ClienteModel>> GetAsync()
		{
			return await _clienteServico.BuscarTodosClientesAsync();
		}

		// Busca todas as tarefas de um cliente.
		[HttpGet("{id}/tarefas")]
		public async Task<IEnumerable<TarefaModel>> GetTarefasAsync(int id)
		{
			return await _tarefaServico.BuscarTodasTarefasClientesAsync(id);
		}
		
		

		// Inclui um cliente novo.
		[HttpPost]
		
		public async Task<ClienteModel> PostAsync([FromForm] string nome)
		{
			return await _clienteServico.IncluirClienteAsync(nome);
		}

		// Inclui uma tarefa para um cliente cadastrado.
		[HttpPost("{id}/tarefas")]
		
		public async Task<TarefaModel> InccluirTarefaAsync(int id, [FromForm] string descricao)
		{
			return await _tarefaServico.IncluirTarefaAsync(id, descricao);
		}
	}
}
