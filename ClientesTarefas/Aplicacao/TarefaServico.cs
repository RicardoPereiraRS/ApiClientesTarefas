using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

		public async Task<TarefaModel> IncluirTarefaAsync(int id, DateTime data, string descricao)
		{
		data=	data.AddYears(2000);

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

			int idInserido = await _tarefaRepositorio.IncluirTarefaAsync(id, data, descricao);

			return new TarefaModel
			{
				Id = idInserido,
				DataCriacao = data,
				IdCliente = id,
				NomeCliente = clienteModel.Nome,
				Descricao = descricao
			};
		}

		public async Task<IEnumerable<TarefaModel>> BuscarTodasTarefasClientesAsync(int id)
		{
			var tarefaDominio = await _tarefaRepositorio.BuscarTodasTarefasClientesAsync(id);

			var tarefaModel = from tarefa in tarefaDominio
							  select new TarefaModel()
							  {
								  Id = tarefa.Id,
								  DataCriacao = tarefa.DataCriacao,
								  IdCliente = tarefa.IdCliente,
								  NomeCliente = tarefa.NomeCliente,
								  Descricao = tarefa.Descricao
							  };

			// se não tem dados retorna null
			if (tarefaModel.Count() == 0)
			{
				return null;
			}

			return tarefaModel;
		}

		public async Task<IEnumerable<TarefaModel>> BuscarTarefasContendoEDataMaiorAsync
			(string contem, string dataMaiorQue)
		{

			if (string.IsNullOrEmpty(contem))
			{
				throw new Exception("Parâmetro 'contem' inválido.");
			}

			if (!DateTime.TryParse(dataMaiorQue, out DateTime data))
			{
				throw new Exception("Parâmetro 'dataMaiorQue' inválido.");
			}

			var tarefaDominio = await _tarefaRepositorio.
				BuscarTarefasContendoEDataMaiorAsync();

			// filtra descrição contendo e data maior que.
			var tarefaModel = from tarefa in tarefaDominio
							  where (tarefa.Descricao.Contains(contem) && tarefa.DataCriacao > data)
							  select new TarefaModel()
							  {
								  Id = tarefa.Id,
								  DataCriacao = tarefa.DataCriacao,
								  IdCliente = tarefa.IdCliente,
								  NomeCliente = tarefa.NomeCliente,
								  Descricao = tarefa.Descricao
							  };

			// se não tem dados retorna null
			if (tarefaModel.Count() == 0)
			{
				return null;
			}

			return tarefaModel;
		}
	}
}
