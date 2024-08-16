using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class EquipamentoMapping : IEntityTypeConfiguration<Equipamento>
{
    public void Configure(EntityTypeBuilder<Equipamento> builder)
    {
        builder.HasKey(e => e.IdEquipamento);

        builder.Property(e => e.IdEquipamento)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

        //Quantidade, Status

        // N:N - Equipamento - Esporte

        // Equipamento com Endereco 1:N
        builder.HasMany(e => e.Esportes)
            .WithOne(es => es.Equipamento)
            .HasForeignKey(es => es.IdEquipamento);

        builder.ToTable("TB_EQUIPAMENTO");
    }
}
