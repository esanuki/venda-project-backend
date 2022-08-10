using ProjectVenda.Core.Data;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Persistance
{
    public class UnitOfWorkCliente : IUnitOfWork
    {
        private readonly ClienteDbContext _context;

        public UnitOfWorkCliente(ClienteDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
