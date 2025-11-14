using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "Indian INR" },
                new Currency() { Id = 2, Title = "USD", Description = "American DOllar" },
                new Currency() { Id = 3, Title = "Euro", Description = "Euro" },
                new Currency() { Id = 4, Title = "Dinar", Description = "Dollar" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { LanguageId = 1, Title = "Hindi", Description = "Hindi" },
                new Language() { LanguageId = 2, Title = "Tamil", Description = "Tamil" },
                new Language() { LanguageId = 3, Title = "Punjabi", Description = "Punjabi" },
                new Language() { LanguageId = 4, Title = "English", Description = "English" }
                );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }

        public DbSet<Author> Authors { get; set; }



    }
}
