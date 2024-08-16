using HubArena.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HubArena.Data.Contexts
{
    public class HubArenaDbContext : DbContext
    {
        public HubArenaDbContext(DbContextOptions options):base(options) { }

        
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Esporte> Esportes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Quadra> Quadras { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaEquipamento> ReservaEquipamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HubArenaDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
