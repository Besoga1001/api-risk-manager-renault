using Microsoft.EntityFrameworkCore;
using project_renault.Models;

namespace project_renault
{
    public class DBSettings : DbContext
    {
        public DBSettings(DbContextOptions<DBSettings> options) : base(options)
        {
        }

        public DbSet<RiskModel> Risk { get; set; }
        public DbSet<UserModel> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configurações adicionais do modelo podem ser adicionadas aqui

            base.OnModelCreating(modelBuilder);
        }

    }
}
