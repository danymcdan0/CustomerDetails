using CustomerDetails.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerDetails.Data
{
    public class CustomerDetailsContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDb");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
