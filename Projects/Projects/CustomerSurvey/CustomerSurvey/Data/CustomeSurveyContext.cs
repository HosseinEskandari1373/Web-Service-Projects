using CustomerSurvey.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CustomerSurvey.Models
{
    public class CustomeSurveyContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSurveys> CustomerSurveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CustomerAnswer> CustomerAnswers { get; set; }

        private IConfiguration configuration;
        public CustomeSurveyContext()
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
                GetSection("ConnectionStrings").GetSection("ConnectStringCustomerSurvey").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Specify the primary key in the entities
            modelBuilder.Entity<Survey>()
                .HasKey(pk => new { pk.SurveyID });
            modelBuilder.Entity<Customer>()
                .HasKey(pk => new { pk.CustomerID });
            modelBuilder.Entity<CustomerSurveys>()
                .HasKey(pk => new { pk.CustomerID, pk.SurveyID });
            modelBuilder.Entity<Question>()
                .HasKey(pk => new { pk.QuestionID });
            modelBuilder.Entity<Answer>()
                .HasKey(pk => new { pk.AnswerID });
            modelBuilder.Entity<CustomerAnswer>()
                .HasKey(pk => new { pk.AnswerID, pk.CustomerID, pk.CustomerAnswers});
        }
    }
}
