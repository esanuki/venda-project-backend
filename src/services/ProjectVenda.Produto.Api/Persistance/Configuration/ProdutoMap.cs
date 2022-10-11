using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectVenda.Produto.Api.Domain.Model;

namespace ProjectVenda.Produto.Api.Persistance.Configuration
{
    public class ProdutoMap : IEntityTypeConfiguration<Domain.Model.Produto>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(80)");

            builder.Property(p => p.ValorUnitario)
                .HasColumnName("ValorUnitario")
                .HasColumnType("numeric(18,0)");
        }
    }
}
