using HubArena.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubArena.Data.Mappings
{
    public class ReservaEquipamentoMapping : IEntityTypeConfiguration<ReservaEquipamento>
    {
        public void Configure(EntityTypeBuilder<ReservaEquipamento> builder)
        {
            builder.HasKey(re => re.IdReservaEquipamento);

            builder.Property(re => re.IdReservaEquipamento)
            .ValueGeneratedOnAdd();

            // Relacionamento com Reserva 1:N
            builder.HasOne(re => re.Reserva)
                .WithMany(r => r.ReservaEquipamentos)
                .HasForeignKey(re => re.IdReserva);

            // Relacionamento com Equipamento 1:1
            builder.HasOne(re => re.Equipamento)
                .WithMany(e => e.ReservaEquipamentos)
                .HasForeignKey(re => re.IdEquipamento);
                

            builder.ToTable("TB_RESERVA_EQUIPAMENTO");

        }
    }
}
