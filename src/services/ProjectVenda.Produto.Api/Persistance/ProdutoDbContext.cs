using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectVenda.Core.Configuration;
using ProjectVenda.Core.Data;

namespace ProjectVenda.Produto.Api.Persistance
{
    public class ProdutoDbContext : ProjectVendaDbContext
    {
        private readonly ConnectionStrings _conn;

        public ProdutoDbContext(IOptions<ConnectionStrings> connection)
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoDbContext).Assembly);
        }
    }
}
