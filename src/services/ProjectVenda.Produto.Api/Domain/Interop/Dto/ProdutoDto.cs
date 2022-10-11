using System;

namespace ProjectVenda.Produto.Api.Domain.Interop.Dto
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
