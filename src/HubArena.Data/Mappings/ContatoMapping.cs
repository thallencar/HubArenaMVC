using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class ContatoMapping : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.HasKey(c => c.IdContato);

        builder.Property(c => c.IdContato)
            .ValueGeneratedOnAdd();

        //DDD, DDI

        builder.Property(c => c.Telefone)
            .IsRequired()
            .HasColumnType("varchar(20)");

        //TipoContato


        // Relacionamento com Funcionario 1:N 
        builder.HasOne(c => c.Funcionario)
            .WithMany(f => f.Contatos)
            .HasForeignKey(c => c.IdFuncionario);

        builder.ToTable("TB_CONTATO");
    }
}
