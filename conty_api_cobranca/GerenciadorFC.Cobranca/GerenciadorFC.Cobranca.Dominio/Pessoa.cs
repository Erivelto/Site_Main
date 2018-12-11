using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorFC.Cobranca.Dominio
{
	public class Pessoa
	{
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public string Razao { get; set; }
		public string Documento { get; set; }
		public string IncricaoMunicipal { get; set; }
		public DateTime DataInclusao { get; set; }
		public DateTime DataAtulizacao { get; set; }
		public DateTime DataAbertura { get; set; }
		public string DescricaoAtividade { get; set; }
		public string CNAE { get; set; }
		public int Status { get; set; }
		public int TipoPessoa { get; set; }
		public bool Excluido { get; set; }
		[NotMapped]
		public string UserStatus { get; set; }
		[NotMapped]
		public bool StatusCobranca { get; set; }
		[NotMapped]
		public bool Assinatura { get; set; }
	}
}
