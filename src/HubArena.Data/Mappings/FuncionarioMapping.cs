using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

namespace HubArena.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<FuncionarioModel>
    {
        public void Configure(EntityTypeBuilder<FuncionarioModel> builder)
        {
            builder.HasKey(f => f.IdFuncionario);

            builder.Property(f => f.IdFuncionario)
                .ValueGeneratedOnAdd();

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(f => f.Cargo)
                .IsRequired()
                .HasColumnType("varchar(90)");

            builder.Property(f => f.Usuario)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(f => f.Senha)
                .IsRequired()
                .HasColumnType("varchar(16)");

            builder.Property(f => f.Documento)
                .IsRequired()
                .HasColumnType("varchar(11)");
            
            builder.Property(f => f.Email)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(f => f.Sexo)
                .HasColumnType("varchar(10)");           

            // Relacionamento com Endereco 1:1
            builder.HasOne(f => f.EnderecoFuncionario)
                .WithOne(e => e.Funcionario)
                .HasForeignKey<EnderecoFuncionarioModel>(e => e.IdFuncionario);

            // Relacionamento com Contato 1:N
            builder.HasMany(f => f.Contatos)
                .WithOne(ct => ct.Funcionario)
                .HasForeignKey(ct => ct.IdFuncionario);

            // Relacionamento com Reservas 1:N
            builder.HasMany(f => f.Reservas)
                .WithOne(r => r.Funcionario)
                .HasForeignKey(r => r.IdFuncionario);

            builder.ToTable("TB_FUNCIONARIO");
        }
    }
}
