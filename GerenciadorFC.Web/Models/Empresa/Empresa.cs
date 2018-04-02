using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorFC.Web.Models.Empresa
{
    public class Empresa
	{
		public string nome { get; set; }
		public string email { get; set; }
		public string celular { get; set; }
		public string telefone { get; set; }
		public string nomeFantasia { get; set; }
		public string razao { get; set; }
		public string rg { get; set; }
		public string endereco { get; set; }
		public IFormFile arquivoRG { get; set; }
		public IFormFile arquivoEnd { get; set; }
		public string cnpj { get; set; }
	}
}
