using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class QuadraMapping : IEntityTypeConfiguration<QuadraModel>
{
    public void Configure(EntityTypeBuilder<QuadraModel> builder)
    {
        builder.HasKey(q => q.IdQuadra);

        builder.Property(q => q.IdQuadra)
            .ValueGeneratedOnAdd();

        builder.Property(q => q.Nome)
            .IsRequired()
            .HasColumnType("varchar(150)");

        //Capacidade, TipoQuadra, StatusQuadra


        // Relacionamento com Endereco 1:1
        builder.HasOne(q => q.Endereco)
            .WithOne(e => e.Quadra)
            .HasForeignKey<QuadraModel>(q => q.IdEndereco);

        // N:N Quadra - Esporte
        

        // Relacionamento Quadra com Reserva 1:N
        builder.HasMany(q => q.Reservas)
            .WithOne(r => r.Quadra)
            .HasForeignKey(r => r.IdQuadra);

        builder.ToTable("TB_QUADRA");
    }
}
