using GerenciadorFC.Cobranca.Dominio;
using Gerencianet.SDK;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
		public Data GeraBoleto(string cpf,string cnpj, string nome, string email, string telefone,  int valor, dynamic endpoints, string vencimento)
		{
			var boleto = new BoletoCliente();
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
                        expire_at = vencimento,
                        customer = new
                        {
							email = email,
							birth = "1980-03-01",
							phone_number = telefone,
							juridical_person = new {
								corporate_name = nome,
								cnpj = cnpj							
							}
						}
                    }
                }
            };
			try
			{
				var response = endpoints.PayCharge(param, body);
				var resultData = response["data"]; 
				
				var result = resultData.ToObject<Data>();

				return result;
			}
			catch (Exception)
			{
				throw;
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
