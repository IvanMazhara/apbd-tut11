using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using apbd_11.Data;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Apbd11Db;Trusted_Connection=True;");

        return new DatabaseContext(optionsBuilder.Options);
    }
}