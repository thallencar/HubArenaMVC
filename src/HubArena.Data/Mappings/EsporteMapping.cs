using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class EsporteMapping : IEntityTypeConfiguration<EsporteModel>
{
    public void Configure(EntityTypeBuilder<EsporteModel> builder)
    {
        builder.HasKey(e => e.IdEsporte);

        builder.Property(e => e.IdEsporte)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

        // Relacionamento Esporte com Equipamento 1:N
        builder.HasMany(e => e.Equipamentos)
            .WithOne(eq => eq.Esporte)
            .HasForeignKey(eq => eq.IdEsporte);

        // Relacionamento Esporte com Quadra 1:N
        builder.HasMany(e => e.Quadras)
            .WithOne(q => q.Esporte)
            .HasForeignKey(q => q.IdEsporte);

        builder.ToTable("TB_ESPORTE");
    }
}
