using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class EquipamentoMapping : IEntityTypeConfiguration<EquipamentoModel>
{
    public void Configure(EntityTypeBuilder<EquipamentoModel> builder)
    {
        builder.HasKey(e => e.IdEquipamento);

        builder.Property(e => e.IdEquipamento)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");


        // Relacionamento com Esporte 1:N
        builder.HasOne(eq => eq.Esporte)
            .WithMany(e => e.Equipamentos)
            .HasForeignKey(eq => eq.IdEsporte);

        // Relacionamento com ReservaEquipamento 1:N
        builder.HasMany(e => e.ReservaEquipamentos)
            .WithOne(re => re.Equipamento)
            .HasForeignKey(e => e.IdEquipamento);

        builder.ToTable("TB_EQUIPAMENTO");
    }
}
