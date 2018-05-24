using System.Net;
using System.Net.Mail;
using GerenciadorFC.Web.Models.Empresa;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFC.Web.Controllers
{
	public class EmpresaController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AbrirEmpresa()
		{
			return View();
		}
		public IActionResult ComoAbrirEmpresa()
		{
			return View();
		}
		public IActionResult EnvioEmpresaNova(Empresa empresa)
		{
			empresa.cnpj = "00.000.000/000-00";
			if (ModelState.IsValid)
			{
				var corpoEmail = "<html xmlns='http://www.w3.org/1999/xhtml'><head>	<style type='text/css'>		body, #bodyTable, #bodyCell, #bodyCell {			height: 100% !important;			margin: 0;			padding: 0;			width: 100% !important;			font-family: Helvetica, Arial, 'Lucida Grande', sans-serif;		}		body, table, td, p, a, li, blockquote {			-ms-text-size-adjust: 100%;			-webkit-text-size-adjust: 100%;			font-weight: normal !important;		}		body, #bodyTable {			background-color: #E1E1E1;		}	</style>	<script type='text/javascript' src='http://gc.kis.v2.scr.kaspersky-labs.com/D23BDC46-5991-6E46-B0E9-985879E9A50E/main.js' charset='UTF-8'></script></head><body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'><center style='background-color:#E1E1E1;'><table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style='table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;'><tr><td align='center' valign='top' id='bodyCell'><table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='500' id='emailBody'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' style='color:#FFFFFF;' bgcolor='#F8F8F8'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'><table border='0' cellpadding='30' cellspacing='0' width='100%'><tr><td align='left' valign='top' class='textContent' style='color: dodgerblue; '><h1>Contfy</h1>  </td></tr></table></td></tr></table></td></tr></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFFFFF'><tr>	<td align='center' valign='top'>		<table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'><table border='0' cellpadding='30' cellspacing='0' width='100%'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td valign='top' class='textContent'><h3 style='color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;'>Cliente quer abrir a empresa, segue os dados:</h3><br /><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Nome:  " + empresa.nome + " </div><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Email: " + empresa.email + " </div><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Celular: " + empresa.celular + " </div><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Telefone: " + empresa.telefone + " </div><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Nome fantasia: " + empresa.nomeFantasia + "</div><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Razão social: " + empresa.razao + "</div></td></tr></table></td>			</tr></table></td></tr></table></td></tr></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFFFFF'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'>						<table border='0' cellpadding='30' cellspacing='0' width='100%'>															<tr>																<td align='center' valign='top'>																	<table border='0' cellpadding='0' cellspacing='0' width='100%'>																		<tr>																			<td valign='top' class='textContent'>																				<div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'>CONTFY tem a oferecer aos nossos clientes a tecnologia às suas mãos para facilitar e agilizar todo esse processo burocrático na qual, estamos preparado, tanto na contabilidade tradicional quanto na online.</div>																			</td>																		</tr>																	</table>																</td>															</tr>														</table>													</td>												</tr>											</table>										</td>									</tr>								</table>							</td>					</tr>					</table>					<table bgcolor='#E1E1E1' border='0' cellpadding='0' cellspacing='0' width='500' id='emailFooter'>						<tr>							<td align='center' valign='top'>								<table border='0' cellpadding='0' cellspacing='0' width='100%'>									<tr>										<td align='center' valign='top'>											<!-- FLEXIBLE CONTAINER // -->											<table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'>												<tr>													<td align='center' valign='top' width='500' class='flexibleContainerCell'>														<table border='0' cellpadding='30' cellspacing='0' width='100%'>															<tr>																<td valign='top' bgcolor='#E1E1E1'>																	<div style='font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;'>																		<div>Contfy &#169;  a sua contabilidade online.</div>																	</div>																</td>															</tr>														</table>													</td>												</tr>											</table>										</td>									</tr>								</table>							</td>						</tr>					</table>				</td>			</tr>		</table>	</center></body></html>";
				MailMessage mail = new MailMessage();

				mail.From = new MailAddress("contato@contfy.com.br");
				mail.To.Add("contato@contfy.com.br");

				mail.Subject = "Cliente quer abrir empresa.";
				mail.Body = corpoEmail;
				mail.IsBodyHtml = true;
				if (empresa.arquivoRG != null)
				{
					if (empresa.arquivoRG.Length < 9485760)
					{
						Attachment attachmentRG = new Attachment(empresa.arquivoRG.OpenReadStream(), "RG_CNH");
						mail.Attachments.Add(attachmentRG);
					}
					else
					{
						ModelState.AddModelError("arquivoRG", "Arquivo superior a 10 Mb!");
						return View("ComoAbrirEmpresa", empresa);
					}
					
				}
				if (empresa.arquivoEnd != null)
				{
					if (empresa.arquivoEnd.Length < 9485760)
					{
						Attachment attachmentEnd = new Attachment(empresa.arquivoEnd.OpenReadStream(), "Endereço");
						mail.Attachments.Add(attachmentEnd);
					}
					else
					{
						ModelState.AddModelError("arquivoEnd", "Arquivo superior a 10 Mb!");
						return View("ComoAbrirEmpresa", empresa);
					}

				}

				SmtpClient smtp = new SmtpClient();
				smtp.Host = "smtp.gmail.com";
				smtp.UseDefaultCredentials = true;
				smtp.EnableSsl = true;
				smtp.Port = 587;
				//smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.Credentials = new NetworkCredential("contato@contfy.com.br", "erivelto33");
				smtp.Send(mail);

				return View("ContatoEmpresa");
			}
			else {
				return View("ComoAbrirEmpresa",empresa);
			}
			
		}
		public IActionResult EmailAbrirEmpresa(Empresa empresa)
		{
			return View();
		}
		public IActionResult EmpresaExistente()
		{
			return View();
		}
		public IActionResult EnvioEmpresaExistente(Empresa empresa)
		{
			if (ModelState.IsValid)
			{
				var corpoEmail = "<html xmlns='http://www.w3.org/1999/xhtml'><head>	<style type='text/css'>		body, #bodyTable, #bodyCell, #bodyCell {			height: 100% !important;			margin: 0;			padding: 0;			width: 100% !important;			font-family: Helvetica, Arial, 'Lucida Grande', sans-serif;		}		body, table, td, p, a, li, blockquote {			-ms-text-size-adjust: 100%;			-webkit-text-size-adjust: 100%;			font-weight: normal !important;		}		body, #bodyTable {			background-color: #E1E1E1;		}	</style>	<script type='text/javascript' src='http://gc.kis.v2.scr.kaspersky-labs.com/D23BDC46-5991-6E46-B0E9-985879E9A50E/main.js' charset='UTF-8'></script></head><body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'><center style='background-color:#E1E1E1;'><table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style='table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;'><tr><td align='center' valign='top' id='bodyCell'><table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='500' id='emailBody'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' style='color:#FFFFFF;' bgcolor='#F8F8F8'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'><table border='0' cellpadding='30' cellspacing='0' width='100%'><tr><td align='left' valign='top' class='textContent' style='color: dodgerblue;'><h1>Contfy</h1>  </td></tr></table></td></tr></table></td></tr></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFFFFF'><tr>	<td align='center' valign='top'>		<table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'><table border='0' cellpadding='30' cellspacing='0' width='100%'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td valign='top' class='textContent'><h3 style='color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;'>Cliente já tem empresa, segue os dados:</h3><br /><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Nome:  " + empresa.nome + " </div><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Email: " + empresa.email + " </div><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> Celular: " + empresa.celular + " </div><div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'> CNPJ: " + empresa.cnpj + " </div></td></tr></table></td>			</tr></table></td></tr></table></td></tr></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFFFFF'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'>						<table border='0' cellpadding='30' cellspacing='0' width='100%'>															<tr>																<td align='center' valign='top'>																	<table border='0' cellpadding='0' cellspacing='0' width='100%'>																		<tr>																			<td valign='top' class='textContent'>																				<div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'>CONTFY tem a oferecer aos nossos clientes a tecnologia às suas mãos para facilitar e agilizar todo esse processo burocrático na qual, estamos preparado, tanto na contabilidade tradicional quanto na online.</div>																			</td>																		</tr>																	</table>																</td>															</tr>														</table>													</td>												</tr>											</table>										</td>									</tr>								</table>							</td>					</tr>					</table>					<table bgcolor='#E1E1E1' border='0' cellpadding='0' cellspacing='0' width='500' id='emailFooter'>						<tr>							<td align='center' valign='top'>								<table border='0' cellpadding='0' cellspacing='0' width='100%'>									<tr>										<td align='center' valign='top'>											<!-- FLEXIBLE CONTAINER // -->											<table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'>												<tr>													<td align='center' valign='top' width='500' class='flexibleContainerCell'>														<table border='0' cellpadding='30' cellspacing='0' width='100%'>															<tr>																<td valign='top' bgcolor='#E1E1E1'>																	<div style='font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;'>																		<div>Contfy &#169;  a sua contabilidade online.</div>																	</div>																</td>															</tr>														</table>													</td>												</tr>											</table>										</td>									</tr>								</table>							</td>						</tr>					</table>				</td>			</tr>		</table>	</center></body></html>";
				MailMessage mail = new MailMessage();

				mail.From = new MailAddress("contato@contfy.com.br");
				mail.To.Add("contato@contfy.com.br");

				mail.Subject = "Cliente tem empresa empresa.";
				mail.Body = corpoEmail;
				mail.IsBodyHtml = true;

				SmtpClient smtp = new SmtpClient();
				smtp.Host = "smtp.gmail.com";
				smtp.UseDefaultCredentials = true;
				smtp.EnableSsl = true;
				smtp.Port = 587;
				//smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.Credentials = new NetworkCredential("contato@contfy.com.br", "erivelto33");
				smtp.Send(mail);
				return View("ContatoEmpresa");
			}
			else
			{
				return View("JaExisteEmpresa");
			}

		}
		public IActionResult ContatoEmpresa()
		{
			return View();
		}
		public IActionResult EmpresaBasica()
		{
			return View();
		}
		public IActionResult ComercioBasico()
		{
			return View();
		}
		public IActionResult JaExisteEmpresa()
		{
			return View();
		}
		public IActionResult TypeWriter()
		{
			return View();
		}
	}
}
