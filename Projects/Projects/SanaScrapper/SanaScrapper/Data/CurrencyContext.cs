using Microsoft.EntityFrameworkCore;

namespace WebScrappingHtmlPage
{
    public class CurrencyContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        //Create a SQLITE DataBase and specify the DataBase name
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=SanaScrapper.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Specify the primary key in the entities
            modelBuilder.Entity<Currency>()
                .HasKey(pk => new { pk.CurrencyId });
            modelBuilder.Entity<CurrencyType>()
                .HasKey(pk => new { pk.TypeId });
            modelBuilder.Entity<CurrencyRate>()
               .HasKey(pk => new { pk.CurrencyId, pk.TypeId, pk.SiteDate });

            //Value entities that have a fixed value
            modelBuilder.Entity<Currency>().HasData(
                    new { CurrencyId = 1, CurrencyName = "یورو", CurrencyCode = "EUR" },
                    new { CurrencyId = 2, CurrencyName = "درهم امارات متحده عربی", CurrencyCode = "AED" },
                    new { CurrencyId = 3, CurrencyName = "یوان  چین", CurrencyCode = "CNY" },
                    new { CurrencyId = 4, CurrencyName = "روپیه  هند", CurrencyCode = "INR" },
                    new { CurrencyId = 5, CurrencyName = "دلار آمریکا", CurrencyCode = "USD" },
                    new { CurrencyId = 6, CurrencyName = "روبل روسيه", CurrencyCode = "RUB" }
                    );
            modelBuilder.Entity<CurrencyType>().HasData(
                    new { TypeId = 1, TypeCurrency = "اسکناس", PriceType = "خرید" },
                    new { TypeId = 2, TypeCurrency = "اسکناس", PriceType = "فروش" },
                    new { TypeId = 3, TypeCurrency = "حواله ارزی", PriceType = "خرید" },
                    new { TypeId = 4, TypeCurrency = "حواله ارزی", PriceType = "فروش" }
                    );
        }
    }
}
