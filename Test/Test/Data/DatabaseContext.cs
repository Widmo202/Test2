namespace Test.Data;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}