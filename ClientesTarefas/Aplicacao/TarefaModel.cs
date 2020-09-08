using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao
{
	public class TarefaModel
	{
		public int Id { get; set; }

		public int IdCliente { get; set; }

		public string Descricao { get; set; }

		public string NomeCliente { get; set; }


		public static string LimitarTamanhoDescricaoTarefa(string descricao)
		{
			descricao = descricao.Trim();

			if (descricao.Length > 80)
			{
				return descricao.Substring(0, 80);
			}
			return descricao;
		}

		public static bool DescricaoTarefaValida(string descricao)
		{
			return !string.IsNullOrEmpty(descricao);
		}


	}
}
