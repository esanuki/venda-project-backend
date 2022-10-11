using ProjectVenda.Core.Data;
using System.Threading.Tasks;

namespace ProjectVenda.Produto.Api.Persistance
{
    public class UnitOfWorkProduto : IUnitOfWork
    {
        private readonly ProdutoDbContext _context;

        public UnitOfWorkProduto(ProdutoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
