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

        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }
        //kuidas yhendada aplikatsioon DB-ga
    }
}
