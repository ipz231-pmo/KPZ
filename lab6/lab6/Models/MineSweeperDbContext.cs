using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models;

public class MineSweeperDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MinesweeperDb;Trusted_Connection=True;");
    }

    private MineSweeperDbContext() : base() { }

    public static MineSweeperDbContext Instance
    { 
        get
        {
            instance ??= new();
            return instance;
        } 
    }
    private static MineSweeperDbContext? instance;

}
