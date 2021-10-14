using Microsoft.EntityFrameworkCore;
using MonolithicWebApplication.Business.Entities;

namespace MonolithicWebApplication.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }

        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\LAPTOP-VBJJ1N26;Initial Catalog=CodeFirstBooks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                optionsBuilder.UseSqlServer("server=LAPTOP-VBJJ1N26;database=MonolithicBooks;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { IdCategory = 1, NameCategory = "Smartphone" , DescriptionCategory = "Smartphone" },
                new Category() { IdCategory = 2, NameCategory = "Consoles" , DescriptionCategory= "Consoles" },
                new Category() { IdCategory = 3, NameCategory = "Laptops" , DescriptionCategory= "Laptops" });
        }
    }
}
