using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;
using HubArena.Business.Enums;

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
            .HasColumnType("varchar(30)");

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

        builder.Property(e => e.TipoEndereco)
           .HasColumnType("varchar(12)");


        builder.HasOne(e => e.Funcionario)
               .WithOne(f => f.Endereco)
               .HasForeignKey<EnderecoModel>(e => e.IdFuncionario);

        builder.HasOne(e => e.Quadra)
               .WithOne(q => q.Endereco)
               .HasForeignKey<EnderecoModel>(e => e.IdQuadra);


        builder.ToTable("TB_ENDERECO");
    }
}