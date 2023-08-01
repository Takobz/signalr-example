using Microsoft.EntityFrameworkCore;
using signalr_example.Data.Entities;

namespace SignalRExample.Data
{
    public interface ISignalRDbContext
    {
        DbSet<Person> Person { get; set; }
        DbSet<Product> Product { get; set; }

        DatabaseResult<Person> AddPerson(Person person);
    }

    public class SignalRDbContext : DbContext, ISignalRDbContext
    {
        public SignalRDbContext(DbContextOptions<SignalRDbContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }

        public DatabaseResult<Person> AddPerson(Person person)
        {
            Person.Add(person);
            return new DatabaseResult<Person> 
            {
                Data = person,
                Status = Status.Success
            };
        }
    }

    public class DatabaseResult<TEntity> where TEntity : Entity
    {
        public TEntity Data { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Success,
        UpdateFailure,
        InsertFailure,
        SelectFailure
    }
}