using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebRestaurante.Models
{
    public class dbWebRestaurante : DbContext
    {

        public dbWebRestaurante() : base("dbWebRestaurante")
        {
        }

        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}