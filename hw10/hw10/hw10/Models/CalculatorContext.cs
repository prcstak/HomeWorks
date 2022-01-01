using Microsoft.EntityFrameworkCore;

namespace hw10.Models
{
    public class CalculatorContext: DbContext
    {
        public DbSet<Cache> Cache { get; set; }

        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=CacheDb;Username=postgres;Password=postgres");
        }
    }
}