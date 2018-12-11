using Gerencianet.SDK;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorFC.Cobranca.Servico.Servicos
{
    public class GeracaoCobrancaGerenciaNet
    {

		private string GeraTransacao(string Nome, int Valor, int Quantidade, dynamic endpoints)
		{
			var body = new
			{
				items = new[] {
				new {
					name = Nome,
					value = Valor,
					amount = Quantidade
					}
				}
			};
			try
			{
				var response = endpoints.CreateCharge(null, body);
				var result = JsonConvert.DeserializeObject<string>(response);
			}
			catch (Exception ex)
			{
				return ex.Message;
			}			
			return "";
		}
		public string GeraBoleto(string documento, string nome, string email, string telefone,  int valor, dynamic endpoints)
		{
			string idTransacao = GeraTransacao(nome, valor, 1,endpoints);

            var param = new
            {
                id = idTransacao
            };
            var body = new
            {
                payment = new
                {
                    banking_billet = new
                    {
                        expire_at =  DateTime.Now.AddDays(2).ToString("yyy-MM-dd"),
                        customer = new
                        {
                            name = nome,
                            email = email,
                            cpf ="27952666878",
                            birth = "17/03/1979",
                            phone_number = "20862051",
							juridical_person = new {

							}
						}
                    }
                }
            };
            var response = endpoints.PayCharge(param, body);
			return "";
		}
		private void GravaTranascao(string transacao, string documento,DateTime data)
		{
			var client = new RestClient("https://gerenciadorfccadastroservicos20180317071207.azurewebsites.net/api/PessoaTransacao");
			var request = new RestRequest();
			var _transacao = new
			{
				transacao = transacao,
				documento = documento,
				dataTransacao = data,
				status = "Novo"
			};
			var body  = JsonConvert.SerializeObject(_transacao);

			request.Method = Method.POST;
			request.AddHeader("Accept", "application/json");
			request.Parameters.Clear();
			request.AddParameter("application/json",body, ParameterType.RequestBody);

			client.Execute(request);
		}
	}
}
