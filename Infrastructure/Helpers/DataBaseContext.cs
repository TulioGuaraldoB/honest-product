namespace HonestProduct.Infrastructure.Helpers;

using Microsoft.EntityFrameworkCore;
using HonestProduct.Web.Models;

public class DataBaseContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataBaseContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public string DSN()
    {
        var host = Environment.GetEnvironmentVariable("DB_HOST");
        var name = Environment.GetEnvironmentVariable("DB_NAME");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        return $"server={host}; database={name}; user={user}; password={password}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var dsn = DSN();
        options.UseMySql(dsn, ServerVersion.AutoDetect(dsn));
    }

    public DbSet<Product>? Products { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);

    }
}