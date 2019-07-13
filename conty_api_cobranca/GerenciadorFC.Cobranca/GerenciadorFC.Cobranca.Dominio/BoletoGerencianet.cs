using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Cobranca.Dominio
{
	public class BoletoGerencianet
	{
		public int code { get; set; }
		public string erro { get; set; }
		public Dictionary<string, Data> Result { get; set; }
	}
}
