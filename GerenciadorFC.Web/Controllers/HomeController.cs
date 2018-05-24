using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
//using GerenciadorFC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {

		
		//public async Task <HttpPostAttribute> HttpPost(FormularioViewModel formularioViewModel)
		//{
	    //	var _form = Mapper.Map<FormularioViewModel>(formularioViewModel);
		//	using (var formEmail = new HttpClient())
		//	{
		//		formEmail.BaseAddress = new Uri("http://localhost:49511/api/Email");
		//		var _retorno = await formEmail.PostAsync("", _form);
		//	}
				

		//}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

		public IActionResult FormularioDeAvalicao()
		{
			ViewData["Message"] = "Your contact page.";
			return View();
		}
        public IActionResult Services()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Portifolio()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		public IActionResult Contato()
		{
			return View();
		}
		public IActionResult Transparencia()
		{
			return View();
		}
		public IActionResult ContatoEnvio(string nome, string email, string assunto, string mensagem)
		{
			MailMessage mail = new MailMessage();

			mail.From = new MailAddress("contato@contfy.com.br");
			mail.To.Add("contato@contfy.com.br");

			mail.Subject = assunto;
			mail.Body = "Nome: " + nome + Environment.NewLine + Environment.NewLine + "Email: "+ email + Environment.NewLine + Environment.NewLine +"Mensagem: "+  mensagem;
			
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.UseDefaultCredentials = true;
			smtp.EnableSsl = true;
			smtp.Port = 587;
			//smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtp.Credentials = new NetworkCredential("contato@contfy.com.br", "erivelto33");
			smtp.Send(mail);
			RedirectToActionResult redirectResult = new RedirectToActionResult("ContatoEmpresa", "Empresa",null);
			return redirectResult;
		}

	}
}
