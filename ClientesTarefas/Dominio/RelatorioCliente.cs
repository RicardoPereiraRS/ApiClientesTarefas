using System.Collections.Generic;

namespace Dominio
{
	public class RelatorioCliente
	{
		public int Id { get; set; }

		public string Nome { get; set; }

		public List<RelatorioTarefa> Tarefas { get; set; }

	}
}
