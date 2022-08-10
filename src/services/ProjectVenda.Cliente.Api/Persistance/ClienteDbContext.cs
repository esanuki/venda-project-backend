using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProjectVenda.Core.Configuration;
using ProjectVenda.Core.Data;

namespace ProjectVenda.Cliente.Api.Persistance
{
    public class ClienteDbContext : ProjectVendaDbContext
    {
        private readonly ConnectionStrings _conn;
        public ClienteDbContext(IOptions<ConnectionStrings> connection)
        {
            _conn = connection.Value;        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn.DbConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteDbContext).Assembly);
        }
    }
}
