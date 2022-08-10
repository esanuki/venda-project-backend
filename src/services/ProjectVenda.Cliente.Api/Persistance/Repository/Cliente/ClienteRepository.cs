using ProjectVenda.Core.Data;

namespace ProjectVenda.Cliente.Api.Persistance.Repository.Cliente
{
    public class ClienteRepository : Repository<Domain.Model.Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteDbContext context) : base(context)
        {
        }
    }
}
