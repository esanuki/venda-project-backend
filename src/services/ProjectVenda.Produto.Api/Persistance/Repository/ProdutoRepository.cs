using ProjectVenda.Core.Data;

namespace ProjectVenda.Produto.Api.Persistance.Repository
{
    public class ProdutoRepository : Repository<Domain.Model.Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProdutoDbContext context) : base(context)
        {
        }
    }
}
