using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Cobranca.Dominio
{
	public class PessoaAssinatura
	{
		public int Codigo { get; set; }
		public int CodigoPessoa { get; set; }
		public string CodigoAssinatura { get; set; }
		public DateTime DataAssinatura { get; set; }
		public string Status { get; set; }
	}
}
