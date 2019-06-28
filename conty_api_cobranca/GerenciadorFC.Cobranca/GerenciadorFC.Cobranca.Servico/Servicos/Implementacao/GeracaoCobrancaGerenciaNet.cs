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
				var value  = response["data"]["charge_id"];
				var retorno = value.Value;
				return retorno.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}			
		}
		public string GeraBoleto(string documento, string nome, string email, string telefone,  int valor, dynamic endpoints)
		{
			string idTransacao = GeraTransacao("Contabilidade Online", valor, 1,endpoints);

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
                            name = "Contabilidade Online",
                            email = email,
							
                            cpf ="27952666878",
                            birth = "1979-03-17",
                            phone_number = "5144916523",
							juridical_person = new {
								corporate_name = "Teste",
								cnpj = "27308027000100"
							}
						}
                    }
                }
            };
			try
			{
				var response = endpoints.PayCharge(param, body);
				var retorno = "";
				return retorno;
			}
			catch (Exception ex)
			{
				return ex.Message.ToString();
			}

			
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
