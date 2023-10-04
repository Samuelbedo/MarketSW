using Market.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(c=>c.Name).IsUnique();//le pongo un index a name y lo convierto en unico (que no se repite)
            modelBuilder.Entity<State>().HasIndex(c => c.Name).IsUnique();//index unico
            //city no tiene index unico porque hay ciudades que se repiten en un mismo pais
        }
    }


}
