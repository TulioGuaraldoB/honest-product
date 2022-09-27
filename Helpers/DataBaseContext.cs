namespace HonestProduct.Helpers;

using Microsoft.EntityFrameworkCore;
using HonestProduct.Models;

public class DataBaseContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataBaseContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = Configuration.GetConnectionString("DSN");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Product> Products { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);

    }
}