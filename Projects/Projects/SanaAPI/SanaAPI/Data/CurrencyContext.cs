using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SanaAPI
{
    public class CurrencyContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        private IConfiguration configuration;
        public CurrencyContext()
        {
            configuration = GetConfiguration();
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Create a SQL Server DataBase and specify the DataBase name
            optionsBuilder.UseSqlServer(configuration.
                GetSection("ConnectionStrings").GetSection("ConnectStringSanaAPI").Value);
        }

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
                    new { TypeId = 4, TypeCurrency = "حواله ارزی", PriceType = "فروش" },
                    new { TypeId = 5, TypeCurrency = "ارز دولتی", PriceType = "نرخ دولتی" }
                    );
        }
    }
}
