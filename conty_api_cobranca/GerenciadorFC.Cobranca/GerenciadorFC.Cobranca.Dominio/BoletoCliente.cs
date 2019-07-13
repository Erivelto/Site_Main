using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Cobranca.Dominio
{
	public class BoletoCliente
	{
		public Int64 Transacao { get; set; }
		public string Link { get; set; }
		public string Barcode { get; set; }
		public string Erro { get; set; }
	}
}
