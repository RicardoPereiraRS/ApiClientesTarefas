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
			data = data.AddYears(2000);

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

			var tarefaModel = tarefaDominio.Select(tarefa => new TarefaModel()
			{
				Id = tarefa.Id,
				DataCriacao = tarefa.DataCriacao,
				IdCliente = tarefa.IdCliente,
				NomeCliente = tarefa.NomeCliente,
				Descricao = tarefa.Descricao
			});

			// se não tem dados retorna null
			if (tarefaModel.Count() == 0)
			{
				return null;
			}

			return tarefaModel;
		}

		public async Task<IEnumerable<TarefaModel>> BuscarTarefasContendoEDataMaiorAsync
			(string? contem, string? dataMaiorQue)
		{

			if (string.IsNullOrEmpty(contem) && string.IsNullOrEmpty(dataMaiorQue))
			{
				throw new Exception("Parâmetro(s) inválido(s) ou ausente(s).");
			}

			DateTime? data = null;

			if (!string.IsNullOrEmpty(dataMaiorQue))
			{
				if (!DateTime.TryParse(dataMaiorQue, out DateTime tmpData))
				{
					throw new Exception("Parâmetro 'dataMaiorQue' inválido.");
				}
				data = tmpData;
			}



			var tarefaDominio = await _tarefaRepositorio.
				BuscarTarefasContendoEDataMaiorAsync();


			if (!string.IsNullOrEmpty(contem))
			{
				tarefaDominio = tarefaDominio.Where(tarefa => tarefa.Descricao.Contains(contem));

			}

			if (!(data == null))
			{
				tarefaDominio = tarefaDominio.Where(tarefa => tarefa.DataCriacao > data);
			}


			var tarefaModel = tarefaDominio.Select(tarefa => new TarefaModel()
			{
				Id = tarefa.Id,
				DataCriacao = tarefa.DataCriacao,
				IdCliente = tarefa.IdCliente,
				NomeCliente = tarefa.NomeCliente,
				Descricao = tarefa.Descricao
			});


			// se não tem dados retorna null
			if (tarefaModel.Count() == 0)
			{
				return null;
			}

			return tarefaModel;
		}
	}
}
