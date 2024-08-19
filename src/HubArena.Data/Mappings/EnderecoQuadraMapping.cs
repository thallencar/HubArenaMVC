using HubArena.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubArena.Data.Mappings
{
    public class EnderecoQuadraMapping : IEntityTypeConfiguration<EnderecoQuadraModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoQuadraModel> builder)
        {
            builder.HasKey(e => e.IdEnderecoQuadra);

            builder.Property(e => e.IdEnderecoQuadra)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.PontoReferencia)
                .HasColumnType("varchar(100)");

            // Relacionamento com Quadra 1:1 
            builder.HasOne(e => e.Quadra)
                .WithOne(q => q.EnderecoQuadra)
                .HasForeignKey<QuadraModel>(q => q.IdEnderecoQuadra);


            builder.ToTable("TB_ENDERECO_QUADRA");
        }
    }
}
