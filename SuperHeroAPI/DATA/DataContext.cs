using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.DATA
{
    public class DataContext : DbContext
    {
        /*contructor*/
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
                                    /*nombre de la tabla*/
            public DbSet<Superhero> Superheroes { get; set; }
        
    }
}
