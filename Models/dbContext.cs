using Microsoft.EntityFrameworkCore;
using PrimoWeb.Models;

public class dbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=database.db");

    public DbSet<Prenotazione> Prenotazione { get ; set; }
    public DbSet<Prodotto> Prodotti { get ; set; }
}

