using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplicacao;
using Dominio;
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


		public ClientesController(IClienteServico clienteServico)
		{
			_clienteServico = clienteServico;
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

		// Inclui um cliente novo.
		[HttpPost]

		public async Task<ClienteModel> PostAsync([FromBody] Cliente cliente)
		{
			return await _clienteServico.IncluirClienteAsync(cliente.Nome);
		}

	}
}
