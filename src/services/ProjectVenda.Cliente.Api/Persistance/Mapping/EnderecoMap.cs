using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectVenda.Cliente.Api.Domain.Model;

namespace ProjectVenda.Cliente.Api.Persistance.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(p => p.Id);


            builder.Property(p => p.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.Cep)
                .HasColumnName("Cep")
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.Estado)
                .HasColumnName("UF")
                .HasColumnType("varchar(2)");
        }
    }
}
