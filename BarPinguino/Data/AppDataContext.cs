using Microsoft.EntityFrameworkCore;
using EVA2TI_BarPinguino.Models;

namespace EVA2TI_BarPinguino.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        public DbSet<Clientes> Clientes { get; set; }

        private void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
