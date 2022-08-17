﻿using System;

namespace ProjectVenda.Cliente.Api.Domain.Interop.ViewModel
{
    public class EnderecoViewModel
    {
        public Guid? Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
