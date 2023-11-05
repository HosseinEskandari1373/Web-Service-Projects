using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SanaAPI
{
    public class CurrencyContext : DbContext
    {

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

        public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Specify the primary key in the entities
            modelBuilder.Entity<Currency>()
                .HasKey(pk => new { pk.CurrencyId });
            modelBuilder.Entity<CurrencyType>()
                .HasKey(pk => new { pk.TypeId });
            modelBuilder.Entity<CurrencyRate>()
               .HasKey(pk => new { pk.CurrencyId, pk.TypeId, pk.SiteDate });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Create a SQL Server DataBase and specify the DataBase name
            optionsBuilder.UseSqlServer(configuration.
                GetSection("ConnectionStrings").GetSection("ConnectStringSanaAPI").Value);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}
    }
}
