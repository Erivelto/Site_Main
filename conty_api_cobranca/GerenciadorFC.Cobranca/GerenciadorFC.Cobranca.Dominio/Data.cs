using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Cobranca.Dominio
{
	public class Data
	{
		public string barcode { get; set; }
		public string link { get; set; }
		public Pdf pdf { get; set; }
		public string expire_at { get; set; }
		public int charge_id { get; set; }
		public string status { get; set; }
		public int total { get; set; }
		public string payment { get; set; }
	}
}
