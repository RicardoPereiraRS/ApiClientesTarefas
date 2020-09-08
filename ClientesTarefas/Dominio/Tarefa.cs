using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
	public class Tarefa
	{
		public int Id { get; set; }

		public int IdCliente { get; set; }

		public string Descricao { get; set; }

		public string NomeCliente { get; set; }
	}
}
