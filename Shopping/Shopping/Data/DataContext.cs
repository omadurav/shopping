using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;

namespace Shopping.Data
{
    public class DataContext : DbContext
    {
        //Conexion a la bd desde el constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Por cada entidad que se mapee, se debe crear una propiedad de tipo DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creamos un index a la bd para que los campos sean unicos para el nombre del pais.
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
