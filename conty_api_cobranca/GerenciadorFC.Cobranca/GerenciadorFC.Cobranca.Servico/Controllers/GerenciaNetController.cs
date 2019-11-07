using GerenciadorFC.Cobranca.Servico.Servicos;
using Gerencianet.SDK;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace GerenciadorFC.Cobranca.Servico.Controllers
{
	[Produces("application/json")]
    [Route("api/GerenciaNet")]
    public class GerenciaNetController : Controller
    {
		private readonly IConfiguration _configuration;
		public GerenciaNetController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		[HttpGet("Boleto/CPF/{cpf}/CNPJ/{cnpj}/Nome/{nome}/Email/{email}/Telefone/{telefone}/Valor/{valor}/Vencimento/{vencimento}")]
		public Dominio.Data GetBoleto(string cpf, string cnpj, string nome, string email, string telefone, int valor ,string vencimento)
		{
			dynamic endpoints = new Endpoints("Client_Id_c6067498ebf19112f0e60f5a8a6c8c7c563feffe", "Client_Secret_5beeb1b799f85e8fb82192c513822dcad32e22dc",false);
			///dynamic endpoints = new Endpoints("Client_Id_4b5eb8f36172ac9b622917fabcd7feee74a07c28", "Client_Secret_ec3ce857c2842a86a11e7a26cf1625ca80095f86", true);
			var servico = new GeracaoCobrancaGerenciaNet();
			return servico.GeraBoleto(cpf,cnpj,nome, email, telefone, valor,endpoints,vencimento);
		}
	}
}