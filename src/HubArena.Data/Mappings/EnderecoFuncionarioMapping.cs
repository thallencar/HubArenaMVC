using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class EnderecoFuncionarioMapping : IEntityTypeConfiguration<EnderecoFuncionarioModel>
{
    public void Configure(EntityTypeBuilder<EnderecoFuncionarioModel> builder)
    {
        builder.HasKey(e => e.IdEnderecoFuncionario);

        builder.Property(e => e.IdEnderecoFuncionario)
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


        // Relacionamento com Funcionario 1:1
        builder.HasOne(e => e.Funcionario)
            .WithOne(f => f.EnderecoFuncionario)
            .HasForeignKey<FuncionarioModel>(f => f.IdEnderecoFuncionario);


        builder.ToTable("TB_ENDERECO_FUNCIONARIO");
    }
}
