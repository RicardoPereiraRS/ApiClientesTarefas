using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
	public class Relatorio
	{
		public int Id { get; set; }

		public int IdCliente { get; set; }

		public string Nome { get; set; }

		public string DescricaoTarefa { get; set; }
	}
}
