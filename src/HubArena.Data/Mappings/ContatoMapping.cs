using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class ContatoMapping : IEntityTypeConfiguration<ContatoModel>
{
    public void Configure(EntityTypeBuilder<ContatoModel> builder)
    {
        builder.HasKey(c => c.IdContato);

        builder.Property(c => c.IdContato)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Telefone)
            .IsRequired()
            .HasColumnType("varchar(20)");

        // Relacionamento com Funcionario 1:N 
        builder.HasOne(c => c.Funcionario)
            .WithMany(f => f.Contatos)
            .HasForeignKey(c => c.IdFuncionario);

        builder.ToTable("TB_CONTATO");
    }
}
