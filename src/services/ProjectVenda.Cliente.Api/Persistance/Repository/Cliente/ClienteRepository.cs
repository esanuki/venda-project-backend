using Microsoft.EntityFrameworkCore;
using ProjectVenda.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Persistance.Repository.Cliente
{
    public class ClienteRepository : Repository<Domain.Model.Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteDbContext context) : base(context)
        {
        }

        public override async Task<Domain.Model.Cliente> GetById(Guid id)
        {
            var result = await _dbSet.AsNoTrackingWithIdentityResolution()
                .Include(c => c.Endereco).AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public override async Task<IEnumerable<Domain.Model.Cliente>> GetAll()
        {
            var result = await _dbSet.AsNoTrackingWithIdentityResolution()
                .Select(c => new Domain.Model.Cliente
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email,
                    DataNascimento = c.DataNascimento
                }).ToListAsync();

            return result;
        }
    }
}
