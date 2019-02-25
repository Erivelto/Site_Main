using GerenciadorFC.Cobranca.Dominio;
using GerenciadorFC.Cobranca.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Uol.PagSeguro.Domain;

namespace GerenciadorFC.Cobranca.Servico.Controllers
{
	[Produces("application/json")]
	[Route("api/PagSeguro")]
	public class PagSeguroController : Controller
	{
		GeracaoCobrancaPagseguro servico = new GeracaoCobrancaPagseguro();
		[HttpGet("ConsultaPessoaCobranca/DataInicial/{initialDate}/DataFinal/{finalDate}")]
		public List<PessoaContabil> Get(DateTime initialDate, DateTime finalDate)
		{
			return servico.ConsultaPessoaContabil(initialDate, finalDate);
		}
		[HttpGet("ConsultaTransacao/Codigo/{codigo}")]
		public Transaction Get(string codigo)
		{
			return servico.ConsultaTransacao(codigo);
		}
		[HttpGet("ConsultaTransacaoStatus/Codigo/{codigo}")]
		public int GetStatus(string codigo)
		{
			return servico.ConsultaTransacaoStatus(codigo);
		}
		[HttpGet("Boleto/Documento/{documento}/Nome/{nome}/Email/{email}/Telefone/{telefone}/CodigoHash/{codigoHash}/Valor/{valor}")]
		public string GetBoleto(string documento, string nome, string email, string telefone, string codigoHash, decimal valor)
		{
			return servico.Boleto(documento, nome, email, telefone, codigoHash, valor);
		}
		[HttpGet("EmissorBoleto")]
		public bool Get(PessoaTomador pessoaTomador)
		{
			return servico.EmissorBoleto(pessoaTomador);
		}
		[HttpGet("Recorrente/Valor/{valor}/CNPJ/{cnpj}/Email/{email}/Nome/{nome}")]
		public string Get(string valor, string cnpj, string email, string nome)
		{
			return servico.Recorrente(Convert.ToDecimal(valor), cnpj, email, nome);
		}
		[HttpGet("ConsultaBoletoRef/{referenceCode}")]
		public bool GetConsultaBoletoRef(String referenceCode)
		{
			return servico.ConsultaBoletoRef(referenceCode);
		}
		[HttpGet("ConsultaRecorrenteRef/{reference}")]
		public bool GetConsultaRecorrenteRef(String reference)
		{
			return servico.ConsultaRecorrenteRef(reference);
		}
		[HttpGet("ConsultaAssintura/{reference}")]
		public PessoaAssinatura ConsultaAssintura(string reference)
		{
			return servico.ConsultaAssintura(reference);
		}
		[HttpGet("ConsultaRecorrenteNotificacao/{code}")]
		public PreApprovalTransaction ConsultaRecorrenteNotificacao(string code)
		{
			return servico.ConsultaRecorrenteNotificacao(code);
		}
		[HttpGet("ConsultaDevedores")]
		public List<Pessoa> ConsultaDevedores()
		{
			return servico.ConsultaDevedores();
		}
	}
}