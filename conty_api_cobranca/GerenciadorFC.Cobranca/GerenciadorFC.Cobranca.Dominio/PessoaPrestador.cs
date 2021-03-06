﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Cobranca.Dominio
{
    public class PessoaPrestador
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Pais { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

    }
}
