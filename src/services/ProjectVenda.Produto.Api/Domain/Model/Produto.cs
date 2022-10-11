using ProjectVenda.Core.DomainObjects;
using System.Security.Permissions;

namespace ProjectVenda.Produto.Api.Domain.Model
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
