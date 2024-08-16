using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubArena.Business.Models;

public class ReservaMapping : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.HasKey(r => r.IdReserva);

        builder.Property(r => r.IdReserva)
            .ValueGeneratedOnAdd();

        //Data, HorarioInicio, HorarioFim, StatusReserva
        

        // Relacionamento com Quadra 1:N
        builder.HasOne(r => r.Quadra)
            .WithMany(q => q.Reservas)
            .HasForeignKey(r => r.IdQuadra);

        // Relacionamento Funcionario 1:N
        builder.HasOne(r => r.Funcionario)
            .WithMany(f => f.Reservas)
            .HasForeignKey(r => r.IdFuncionario);

        // Relacionamento com ReservaEquipamento 1:N
        builder.HasMany(r => r.ReservaEquipamentos)
            .WithOne(re => re.Reserva)
            .HasForeignKey(re => re.IdReserva);


        builder.ToTable("TB_RESERVA");
    }
}
