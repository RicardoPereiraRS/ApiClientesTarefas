using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao
{
	public class RelatorioClienteModel
	{
		public int Id { get; set; }

		public string Nome { get; set; }

		public List<RelatorioTarefaModel> Tarefas { get; set; }
	}
}
