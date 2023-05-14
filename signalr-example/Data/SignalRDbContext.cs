using Microsoft.EntityFrameworkCore;

namespace SignalRExample.Data
{
    public interface ISignalRDbContext
    {
        DbSet<Person> Person { get; set; }
        DbSet<Product> Product { get; set; }
    }

    public class SignalRDbContext : DbContext, ISignalRDbContext
    {
        public SignalRDbContext(DbContextOptions<SignalRDbContext> options) : base(options){}

        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}