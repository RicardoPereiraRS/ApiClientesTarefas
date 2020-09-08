using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio;
using Infraestrutura;

namespace Aplicacao
{
	public class TarefaServico : ITarefaServico
	{
		IClienteRepositorio _clienteRepositorio;
		ITarefaRepositorio _tarefaRepositorio;
		public TarefaServico(ITarefaRepositorio tarefaRepositorio, IClienteRepositorio clienteRepositorio)
		{
			_tarefaRepositorio = tarefaRepositorio;
			_clienteRepositorio = clienteRepositorio;
		}

		public async Task<TarefaModel> IncluirTarefaAsync(int id, string descricao)
		{

			// se parametro descricao ausente
			if (!TarefaModel.DescricaoTarefaValida(descricao))
			{
				throw new Exception("O Parâmetro descricão é inválida");
			}

			descricao = TarefaModel.LimitarTamanhoDescricaoTarefa(descricao);

			var clienteModel = await _clienteRepositorio.BuscarClienteAsync(id);

			// se o clinte não está cadastrado lança exceção.
			if (clienteModel == null)
			{
				throw new Exception("Este cliente não está cadastrado");
			}

			int idInserido = await _tarefaRepositorio.IncluirTarefaAsync(id, descricao);

			return new TarefaModel
			{
				Id = idInserido,
				IdCliente = id,
				NomeCliente = clienteModel.Nome,
				Descricao = descricao
			};
		}

		public async Task<IEnumerable<TarefaModel>> BuscarTodasTarefasClientesAsync(int id)
		{
			var tarefaDominio = await _tarefaRepositorio.BuscarTodasTarefasClientesAsync(id);

			List<TarefaModel> tarefaModel = new List<TarefaModel>();

			foreach (Tarefa tarefa in tarefaDominio)
			{
				tarefaModel.Add(new TarefaModel
				{
					Id = tarefa.Id,
					IdCliente = tarefa.IdCliente,
					NomeCliente = tarefa.NomeCliente,
					Descricao = tarefa.Descricao
				});
			}

			// se não tem dados retorna null
			if (tarefaModel.Count == 0)
			{
				return null;
			}

			return tarefaModel;
		}
	}
}
