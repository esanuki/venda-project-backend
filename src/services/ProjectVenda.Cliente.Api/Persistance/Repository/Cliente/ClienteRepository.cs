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
            var result = await _dbSet
                .Include(c => c.Endereco).AsNoTrackingWithIdentityResolution()
                .Select(c => new Domain.Model.Cliente
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email,
                    Cpf = c.Cpf,
                    DataNascimento = c.DataNascimento,
                    Endereco = new Domain.Model.Endereco
                    {
                        Logradouro = c.Endereco.Logradouro,
                        Cep = c.Endereco.Cep,
                        Estado = c.Endereco.Estado,
                        Cidade = c.Endereco.Cidade
                    }
                }).ToListAsync();

            return result;
        }
    }
}
