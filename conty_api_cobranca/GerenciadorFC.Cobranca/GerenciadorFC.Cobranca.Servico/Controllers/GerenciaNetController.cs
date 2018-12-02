using GerenciadorFC.Cobranca.Servico.Servicos;
using Gerencianet.SDK;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
		[HttpGet("Boleto/Documento/{documento}/Nome/{nome}/Email/{email}/Telefone/{telefone}/Valor/{valor}")]
		public string GetBoleto(string documento, string nome, string email, string telefone, decimal valor)
		{
			dynamic endpoints = new Endpoints(_configuration["Seguranca:ClientKey"], _configuration["Seguranca:ApiKey"], true);
			var servico = new GeracaoCobrancaGerenciaNet();
			return servico.GeraBoleto(documento, nome, email, telefone, valor,endpoints);
		}
	}
}