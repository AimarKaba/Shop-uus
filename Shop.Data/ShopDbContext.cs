using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;

namespace Shop.Data
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Spaceship> Spaceship { get; set; }

        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
        //kuidas yhendada aplikatsioon DB-ga
    }
}
