using GerenciadorFC.Cobranca.Dominio;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Constants.PreApproval;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Domain.Direct;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Service;

namespace GerenciadorFC.Cobranca.Servico.Servicos
{
	public class GeracaoCobrancaPagseguro
	{
		public bool EmissorBoleto(PessoaTomador pessoaTomador)
		{
			bool isSandbox = false;
			EnvironmentConfiguration.ChangeEnvironment(isSandbox);
			BoletoCheckout checkout = new BoletoCheckout();

			checkout.PaymentMode = PaymentMode.DEFAULT;

			checkout.ReceiverEmail = "fabio@contfy.com.br";

			checkout.Currency = Currency.Brl;

			checkout.Items.Add(new Item("0001", "Contabilidade Online", 1, 69.90m));

			checkout.Reference = pessoaTomador.Documento;

			checkout.Shipping = new Shipping();
			checkout.Shipping.ShippingType = ShippingType.Sedex;
			checkout.Shipping.Cost = 0.00m;
			checkout.Shipping.Address = new Address(
				"BRA",
				"SP",
				"Sao Paulo",
				"Jardim Paulistano",
				"01452002",
				"Av. Brig. Faria Lima",
				"1384",
				"5o andar"
			);
			checkout.Sender = new Sender(
					pessoaTomador.Nome,
					pessoaTomador.Email,
				new Phone("11", pessoaTomador.Telefone)
			);
			checkout.Sender.Hash = pessoaTomador.CodigoHash;
			SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), "27952666878");
			checkout.Sender.Documents.Add(senderCPF);

			checkout.NotificationURL = "http://www.lojamodelo.com.br";

			try
			{
				AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
				Transaction result = TransactionService.CreateCheckout(credentials, checkout);
				return true;

			}
			catch (PagSeguroServiceException exception)
			{
				return false;
			}
		}
		public string Boleto(string documento, string nome, string email, string telefone, string codigoHash, decimal valor)
		{
			bool isSandbox = false;
			EnvironmentConfiguration.ChangeEnvironment(isSandbox);
			BoletoCheckout checkout = new BoletoCheckout();

			var endereco = GetEndereco(documento);

			checkout.PaymentMode = PaymentMode.DEFAULT;

			checkout.ReceiverEmail = "fabio@contfy.com.br";

			checkout.Currency = Currency.Brl;

			checkout.Items.Add(new Item("0001", "Contabilidade Online", 1, valor));

			checkout.Reference = documento;

			checkout.Shipping = new Shipping();
			checkout.Shipping.ShippingType = ShippingType.Sedex;
			checkout.Shipping.Cost = 0.00m;
			checkout.Shipping.Address = new Address(
				"BRA",
				endereco.UF,
				endereco.Cidade,
				endereco.Bairro,
				endereco.CEP,
				endereco.TipoEnd + " " + endereco.Logradouro,
				endereco.Numrero,
				endereco.Complemento
			);
			checkout.Sender = new Sender(
					nome,
					email,
				new Phone("11", telefone)
			);
			checkout.Sender.Hash = codigoHash;
			SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CNPJ"), documento);
			checkout.Sender.Documents.Add(senderCPF);

			try
			{
				AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
				Transaction result = TransactionService.CreateCheckout(credentials, checkout);

				GravaTransacao("2", codigoHash, Convert.ToDecimal(valor), result.PaymentLink, result.Code, result.LastEventDate.Day, result.LastEventDate.Month, documento);

				///var corpo = " <html xmlns='http://www.w3.org/1999/xhtml'><head>	<style type='text/css'>		body, #bodyTable, #bodyCell, #bodyCell {			height: 100% !important;			margin: 0;			padding: 0;			width: 100% !important;			font-family: Helvetica, Arial, 'Lucida Grande', sans-serif;		}		body, table, td, p, a, li, blockquote {			-ms-text-size-adjust: 100%;			-webkit-text-size-adjust: 100%;			font-weight: normal !important;		}		body, #bodyTable {			background-color: #E1E1E1;		}	</style>	<script type='text/javascript' src='http://gc.kis.v2.scr.kaspersky-labs.com/D23BDC46-5991-6E46-B0E9-985879E9A50E/main.js' charset='UTF-8'></script></head><body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'><center style='background-color:#E1E1E1;'><table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style='table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;'><tr><td align='center' valign='top' id='bodyCell'><table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='500' id='emailBody'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' style='color:#FFFFFF;' bgcolor='#F8F8F8'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'><table border='0' cellpadding='30' cellspacing='0' width='100%'><tr><td align='left' valign='top' class='textContent' style='color: dodgerblue; '><h1>Contfy</h1>  </td></tr></table></td></tr></table></td></tr></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFFFFF'><tr>	<td align='center' valign='top'>		<table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'><table border='0' cellpadding='30' cellspacing='0' width='100%'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td valign='top' class='textContent'><h3 style='color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;'>Segue o link de pagamento para uso da CONTFY:</h3><br /> </td></tr></table></td>			</tr></table></td></tr></table></td></tr></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%'>										<tr style='padding-top:0;'>									<td align='center' valign='top'>																								<table border='0' cellpadding='30' cellspacing='0' width='500' class='flexibleContainer'>													<tr>														<td style='padding-top:0;' align='center' valign='top' width='500' class='flexibleContainerCell'>															<table border='0' cellpadding='0' cellspacing='0' width='50%' class='emailButton' style='background-color: #3498DB;'>																<tr>																<td align='center' valign='middle' class='buttonContent' style='padding-top:15px;padding-bottom:15px;padding-right:15px;padding-left:15px;'>																		<a style='color:#FFFFFF;text-decoration:none;font-family:Helvetica,Arial,sans-serif;font-size:20px;line-height:135%;' href='" + result.PaymentLink.ToString() + "' target='_blank'>Acesse aqui</a>																	</td>																</tr>														</table>																							</td>													</tr>												</table>																						</td>										</tr>									</table>																	</td>							</tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFFFFF'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'>						<table border='0' cellpadding='30' cellspacing='0' width='100%'>															<tr>																<td align='center' valign='top'>																	<table border='0' cellpadding='0' cellspacing='0' width='100%'>																		<tr>																			<td valign='top' class='textContent'>																				<div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'>CONTFY tem a oferecer aos nossos clientes a tecnologia às suas mãos para facilitar e agilizar todo esse processo burocrático na qual, estamos preparado, tanto na contabilidade tradicional quanto na online.</div>																			</td>																		</tr>																	</table>																</td>															</tr>														</table>													</td>												</tr>											</table>										</td>									</tr>								</table>							</td>					</tr>					</table>					<table bgcolor='#E1E1E1' border='0' cellpadding='0' cellspacing='0' width='500' id='emailFooter'>						<tr>							<td align='center' valign='top'>								<table border='0' cellpadding='0' cellspacing='0' width='100%'>									<tr>										<td align='center' valign='top'>											<!-- FLEXIBLE CONTAINER // -->											<table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'>												<tr>													<td align='center' valign='top' width='500' class='flexibleContainerCell'>														<table border='0' cellpadding='30' cellspacing='0' width='100%'>															<tr>																<td valign='top' bgcolor='#E1E1E1'>																	<div style='font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;'>																		<div>Contfy &#169;  a sua contabilidade online.</div>																	</div>																</td>															</tr>														</table>													</td>												</tr>											</table>										</td>									</tr>								</table>							</td>						</tr>					</table>				</td>			</tr>		</table>	</center></body></html>";

				return result.PaymentLink;

			}
			catch (PagSeguroServiceException exception)
			{
				return exception.Message;
			}
		}
		public string Recorrente(decimal valor, string cnpj, string email, string nome)
		{
			bool isSandbox = false;
			EnvironmentConfiguration.ChangeEnvironment(isSandbox);
			PreApprovalRequest preApproval = new PreApprovalRequest();
			preApproval.Currency = Currency.Brl;

			preApproval.Reference = cnpj;
			preApproval.Sender = new Sender(
				nome,
				email.ToString(),
				new Phone("00", "00000000")
			);

			var now = DateTime.Now;
			preApproval.PreApproval = new PreApproval();
			preApproval.PreApproval.Charge = Charge.Auto;
			preApproval.PreApproval.Name = "CONTFY - CONTABILIDADE ONLINE";
			preApproval.PreApproval.AmountPerPayment = valor;
			preApproval.PreApproval.MaxAmountPerPeriod = valor;
			preApproval.PreApproval.MaxPaymentsPerPeriod = 5;
			preApproval.PreApproval.Details = string.Format("Todo dia {0} será cobrado o valor de {1} referente a CONTABILIDADE ONLINE.", now.Day, preApproval.PreApproval.AmountPerPayment.ToString("C2"));

			preApproval.PreApproval.Period = Period.Monthly;
			preApproval.PreApproval.DayOfMonth = now.Day;
			preApproval.PreApproval.InitialDate = now;
			preApproval.PreApproval.FinalDate = now.AddYears(5);
			preApproval.PreApproval.MaxTotalAmount = 10000.00m;

			preApproval.RedirectUri = new Uri("https://gerenciadorfcadministrativoweb20180319080544.azurewebsites.net/Home/PosPagIndex?email=" + email + "&status=ativo");

			SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), "27952666878");
			preApproval.Sender.Documents.Add(senderCPF);
			try
			{
				AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
				Uri preApprovalRedirectUri = preApproval.Register(credentials);

				GravaTransacao("1", "", valor, preApprovalRedirectUri.ToString(), "", 0, 0, cnpj);

				return preApprovalRedirectUri.ToString();
			}
			catch (PagSeguroServiceException exception)
			{
				return exception.InnerException.ToString();
			}
		}
		public Endereco GetEndereco(string cnpj)
		{
			var endereco = new Endereco();

			var client = new RestClient("https://gerenciadorfccadastroservicos20180317071207.azurewebsites.net/api/Pessoa/Documento/" + cnpj.Replace(".", "").Replace("-", "").Replace("/", ""));
			var request = new RestRequest();

			request.Method = Method.GET;
			request.AddHeader("Accept", "application/json");
			request.Parameters.Clear();
			request.AddParameter("application/json", ParameterType.QueryString);

			var response = client.Execute(request);
			endereco = JsonConvert.DeserializeObject<Endereco>(response.Content);

			return endereco;

		}
		public Transaction ConsultaTransacao(string transacao)
		{
			bool isSandbox = false;
			EnvironmentConfiguration.ChangeEnvironment(isSandbox);
			AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
			string transactionCode = transacao;
			try
			{
				Transaction transaction = TransactionSearchService.SearchByCode(
						   credentials,
						   transactionCode);
				return transaction;
			}
			catch (PagSeguroServiceException exception)
			{
				return null;
			}
		}
		public TransactionSearchResult ConsultaTransacaoDate(DateTime InitialDate, DateTime FinalDate)
		{
			bool isSandbox = false;

			EnvironmentConfiguration.ChangeEnvironment(isSandbox);

			AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

			int maxPageResults = 1000;

			int pageNumber = 1;

			TransactionSearchResult result =
				TransactionSearchService.SearchByDate(
					credentials,
					InitialDate,
					FinalDate,
					pageNumber,
					maxPageResults);
			return result;
		}
		public bool ConsultaRecorrenteRef(String reference)
		{
			bool valida = false;
			bool isSandbox = false;
			EnvironmentConfiguration.ChangeEnvironment(isSandbox);

			var myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
			DateTime initialDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.AddMonths(-4), myTimeZone);
			DateTime finalDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
			int maxPageResults = 10;
			int pageNumber = 1;
			AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
			try
			{

				PreApprovalSearchResult result =
					PreApprovalSearchService.SearchByReference(
						credentials,
						reference,
						initialDate,
						finalDate,
						pageNumber,
						maxPageResults
					);

				if (result.PreApprovals.Count > 1)
				{
					var dateMax = result.PreApprovals.Select(m => m.LastEventDate).Max();
					var resultMax = result.PreApprovals.Where(m => m.Status == "ACTIVE").FirstOrDefault();
					if (resultMax != null)
					{
						valida = true;
					}						
					else
						valida = ConsultaBoletoRef(reference);
				}
				else
				{
					if (result.PreApprovals.Count != 0)
					{
						if (result.PreApprovals[0].Status == "ACTIVE")
							valida = true;
						else
						{
							valida = ConsultaBoletoRef(reference);
						}
					}
					else
					{
						valida = ConsultaBoletoRef(reference);
					}
				}

				return valida;
			}
			catch (PagSeguroServiceException exception)
			{
				var ex = exception;
				return valida;
			}
		}
		public bool ConsultaBoletoRef(String reference)
		{
			bool valida = false;
			bool isSandbox = false;
			EnvironmentConfiguration.ChangeEnvironment(isSandbox);
			var myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
			var dataAtual = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);

			try
			{

				AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

				// Realizando a consulta
				TransactionSearchResult result = TransactionSearchService.SearchByReference(credentials, reference);

				foreach (var item in result.Transactions.Where(m => m.LastEventDate.Month == dataAtual.Month && m.LastEventDate.Year == dataAtual.Year))
				{
					if (item.LastEventDate.Day < DateTime.Now.Day && item.TransactionStatus != 3)
					{
						valida = false;
					}
					else
					{
						valida = true;
					}
				}
			}
			catch (PagSeguroServiceException exception)
			{
			}
			return valida;
		}
		public List<PessoaContabil> ConsultaPessoaContabil(DateTime initialDate, DateTime finalDate)
		{
			var pessoacontabil = new List<PessoaContabil>();
			var ListaTransacao = this.ConsultaTransacaoDate(initialDate, finalDate);

			foreach (var item in ListaTransacao.Transactions)
			{
				var pessoaCont = new PessoaContabil();
				var transac = this.ConsultaTransacao(item.Code);
				if (transac != null)
				{
					pessoaCont.Reference = transac.Reference;
					pessoaCont.Status = transac.TransactionStatus.ToString();
					pessoaCont.Transacao = transac.Code;
					pessoaCont.DataTransacao = transac.Date;
					pessoaCont.DataPagamento = transac.LastEventDate;
					pessoaCont.ValorLiquido = transac.NetAmount;
					pessoaCont.ValorBruto = transac.GrossAmount;
					pessoaCont.DateVencimento = transac.Date;
					pessoaCont.TipoCobranca = transac.PaymentMethod.PaymentMethodType;
					pessoacontabil.Add(pessoaCont);
				}
			}
			return pessoacontabil;
		}
		private void GravaTransacao(string pagamento, string CodigoHash, decimal valor, string url, string transacao, int diaVencimento, int MesVencimento, string documento)
		{
			var _transacao = new PessoaContabil();
			_transacao.CodigoHash = CodigoHash;
			_transacao.ValorBruto = valor;
			_transacao.ValorLiquido = valor;
			_transacao.UrlBoleto = url;
			_transacao.Transacao = transacao;
			_transacao.TipoCobranca = Convert.ToInt32(pagamento);
			_transacao.Status = "pagamentoandamento";
			_transacao.Reference = documento;
			_transacao.DateVencimento = DateTime.Now.AddDays(4);
			_transacao.DataTransacao = DateTime.Now;
			_transacao.DataPagamento = DateTime.Now;
			_transacao.DiaVencimento = diaVencimento;
			_transacao.MesVencimento = MesVencimento;

			var body = JsonConvert.SerializeObject(_transacao);

			var client = new RestClient("https://gerenciadorfccadastroservicos20180317071207.azurewebsites.net/api/PessoaCobranca");
			var request = new RestRequest();

			request.Method = Method.POST;
			request.AddHeader("Accept", "application/json");
			request.Parameters.Clear();
			request.AddParameter("application/json", body, ParameterType.RequestBody);

			var response = client.Execute(request);
			var content = response.Content;
		}

		public List<Pessoa> ConsultaDevedores()
		{
			var _clientes = ListaCliente();
			var result = new List<Pessoa>();

			foreach (var item in _clientes)
			{
				item.Assinatura = IsAssinatura(item.Documento);
				item.StatusCobranca = ConsultaRecorrenteRef(item.Documento);
				result.Add(item);
			}
			return result;
		}
		private bool IsAssinatura(string reference)
		{
			bool valida = false;
			bool isSandbox = false;
			EnvironmentConfiguration.ChangeEnvironment(isSandbox);

			var myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
			DateTime initialDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.AddMonths(-4), myTimeZone);
			DateTime finalDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
			int maxPageResults = 10;
			int pageNumber = 1;
			AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
			try
			{

				PreApprovalSearchResult result =
					PreApprovalSearchService.SearchByReference(
						credentials,
						reference,
						initialDate,
						finalDate,
						pageNumber,
						maxPageResults
					);

				if (result.PreApprovals.Count >= 1)
				{
					var dateMax = result.PreApprovals.Select(m => m.LastEventDate).Max();
					var resultMax = result.PreApprovals.Where(m => m.LastEventDate == dateMax).FirstOrDefault();
					if (resultMax.Status == "ACTIVE")
					{
						valida = true;
					}
				}
				return valida;
			}
			catch (PagSeguroServiceException exception)
			{
				return valida;
			}
		}
		public List<Pessoa> ListaCliente()
		{
			var client = new RestClient("https://gerenciadorfccadastroservicos20180317071207.azurewebsites.net/api/Pessoa");
			var request = new RestRequest();

			request.Method = Method.GET;
			request.AddHeader("Accept", "application/json");
			request.Parameters.Clear();
			request.AddParameter("application/json", ParameterType.QueryString);

			var response = client.Execute(request);
			var cliente = JsonConvert.DeserializeObject<List<Pessoa>>(response.Content);

			return cliente;
		}
	}
}
