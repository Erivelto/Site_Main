using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Cobranca.Dominio
{
    public class PessoaContabil
    {
		public int Codigo { get; set; }
		public string Reference { get; set; }
		public string CodePrepoval { get; set; }
		public string Transacao { get; set; }
		public DateTime DataTransacao { get; set; }
		public DateTime DateVencimento { get; set; }
		public DateTime DataPagamento { get; set; }
		public string Status { get; set; }
		public decimal ValorBruto { get; set; }
		public decimal ValorLiquido { get; set; }
		public int TipoCobranca { get; set; }
		public string UrlBoleto { get; set; }
		public string CodigoHash { get; set; }
		public int DiaVencimento { get; set; }
		public int MesVencimento { get; set; }
	}
}
