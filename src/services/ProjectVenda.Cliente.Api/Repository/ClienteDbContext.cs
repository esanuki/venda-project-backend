using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using ProjectVenda.Core.Data;

namespace ProjectVenda.Cliente.Api.Repository
{
    public class ClienteDbContext : ProjectVendaDbContext
    {
        public ClienteDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteDbContext).Assembly);
        }
    }
}
