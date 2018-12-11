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
		public string GetBoleto(string documento, string nome, string email, string telefone, int valor)
		{
			dynamic endpoints = new Endpoints("Client_Id_4b5eb8f36172ac9b622917fabcd7feee74a07c28", "Client_Secret_ec3ce857c2842a86a11e7a26cf1625ca80095f86", true);
			var servico = new GeracaoCobrancaGerenciaNet();
			return servico.GeraBoleto(documento, nome, email, telefone, valor,endpoints);
		}
	}
}