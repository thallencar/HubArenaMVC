using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class EnderecoMapping : IEntityTypeConfiguration<EnderecoModel>
{
    public void Configure(EntityTypeBuilder<EnderecoModel> builder)
    {
        builder.HasKey(e => e.IdEndereco);

        builder.Property(e => e.IdEndereco)
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


        builder.ToTable("TB_ENDERECO");
    }
}
