using Microsoft.EntityFrameworkCore;

namespace BEERCRUD.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }
        // Indicamos los modelos que se pasaran a la base de datos
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
