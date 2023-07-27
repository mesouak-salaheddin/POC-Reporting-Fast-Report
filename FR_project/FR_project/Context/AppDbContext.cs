using FR_project.Models;
using Microsoft.EntityFrameworkCore;


namespace FR_project.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Entreprise> Entreprises { get; set;}
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Categorie> Categories { get; set; }

    }
}
