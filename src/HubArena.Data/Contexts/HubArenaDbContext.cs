using HubArena.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace HubArena.Data.Contexts
{
    public class HubArenaDbContext : DbContext
    {
        public HubArenaDbContext(DbContextOptions options):base(options) { }

        
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<EnderecoFuncionarioModel> EnderecoFuncionarios { get; set; }
        public DbSet<EnderecoQuadraModel> EnderecoQuadras { get; set; }
        public DbSet<EquipamentoModel> Equipamentos { get; set; }
        public DbSet<EsporteModel> Esportes { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<QuadraModel> Quadras { get; set; }
        public DbSet<ReservaModel> Reservas { get; set; }
        public DbSet<ReservaEquipamentoModel> ReservaEquipamentos { get; set; }

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
