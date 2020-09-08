namespace Aplicacao
{
	public class ClienteModel
	{
		public int Id { get; set; }

		public string Nome { get; set; }

		public static string LimitarTamanhoNomeCliente(string nome)
		{
			nome = nome.Trim();

			if (nome.Length > 50)
			{
				return nome.Substring(0, 50);
			}
			return nome;
		}
				
		public static bool NomeClienteaValido(string nome)
		{
			return !string.IsNullOrEmpty(nome);
		}

	}
}
