using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonolithicWebApplication.Business.Entities;

namespace MonolithicWebApplication.Infraestructure.Data
{
    public class ApplicationDbContext : IdentityDbContext //DbContext
    {
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ApplicationUser> Users { set; get; }

        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<DbContext> options): base(options) { }

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
            base.OnModelCreating(modelBuilder);

            // Seeding Admin user
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<Category>().HasData(
                new Category() { IdCategory = 1, NameCategory = "Smartphone" , DescriptionCategory = "Smartphone" },
                new Category() { IdCategory = 2, NameCategory = "Consoles" , DescriptionCategory= "Consoles" },
                new Category() { IdCategory = 3, NameCategory = "Laptops" , DescriptionCategory= "Laptops" });

            modelBuilder.Entity<Product>().HasData(
                new Product() { IdProduct = 1, NameProduct = "Xbox", DescriptionProduct = "Xbox Series X", ImageUrlProduct = "https://as.com/meristation/imagenes/2020/11/05/reportajes/1604585433_047408_1604585657_noticia_normal.jpg", MemoryProduct = 10, StorageCapacityProduct = 1000, PriceProduct = 2550000, ResolutionImageProduct = "FHD 4K", CategoryId = 2 },
                new Product() { IdProduct = 2, NameProduct = "Playstation", DescriptionProduct = "Playstation 5", ImageUrlProduct = "https://cdn.computerhoy.com/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2020/06/playstation-5-1964465.jpg?itok=EXk3Upcm", MemoryProduct = 10, StorageCapacityProduct = 1000, PriceProduct = 2550000, ResolutionImageProduct = "FHD 4K", CategoryId = 2 },
                new Product() { IdProduct = 3, NameProduct = "HP", DescriptionProduct = "HP 245 G7", ImageUrlProduct = "https://redecdecolombia.com/wp-content/uploads/2020/08/HP-245-G7-.jpg", MemoryProduct = 8, StorageCapacityProduct = 1000, PriceProduct = 1850000, ResolutionImageProduct = "1200x720", CategoryId = 3 },
                new Product() { IdProduct = 4, NameProduct = "Lenovo", DescriptionProduct = "Yoga c740", ImageUrlProduct = "https://www.pcworld.es/cmsdata/reviews/3783451/lenovo_yoga_c740_review_3_thumb1200_16-9.jpg", MemoryProduct = 10, StorageCapacityProduct = 256, PriceProduct = 3550000, ResolutionImageProduct = "1500x900", CategoryId = 3 });
        }
    }
}
