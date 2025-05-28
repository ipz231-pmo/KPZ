using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace lab6.Models;

public class MineSweeperDbContext : DbContext
{
    public MineSweeperDbContext(DbContextOptions<MineSweeperDbContext> options)
        : base(options)
    { }

    public MineSweeperDbContext()
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();
            var conn = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(conn);
        }
    }

    public DbSet<User> Users => Set<User>();
}
