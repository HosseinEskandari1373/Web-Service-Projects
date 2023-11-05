using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectXrmAPI.Models
{
    public class ReadData
    {
        /*Contact*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        /*Account*/
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        /*Currency*/
        public DateTime SiteDate { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyType { get; set; }
        public string PriceType { get; set; }
        public decimal Price { get; set; }

        /*Credentials*/
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Url_IS { get; set; }
        public Guid Id { get; set; }

        public List<ReadData> readData { get; } = new List<ReadData>();
    }
}
