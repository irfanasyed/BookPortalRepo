using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.Models
{
    public class BookStorePortalDbContext:DbContext
    {
        public BookStorePortalDbContext(DbContextOptions<BookStorePortalDbContext> Options) : base(Options){

        }
        public  DbSet<Author> Authors { get; set; }

        public  DbSet<Discount> Discounts { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<PubInfo> PubInfos { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Roysched> Royscheds { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Title> Titles { get; set; }

        public DbSet<Titleauthor> Titleauthors { get; set; }

    }
}
