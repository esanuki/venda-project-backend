using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectVenda.Cliente.Api.Persistance.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Domain.Model.Cliente>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)");

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime2");

            builder.Property(p => p.EnderecoId)
                .HasColumnName("EnderecoId")
                .HasColumnType("uniqueidentifier");

            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Domain.Model.Cliente>(c => c.EnderecoId);
        }
    }
}
