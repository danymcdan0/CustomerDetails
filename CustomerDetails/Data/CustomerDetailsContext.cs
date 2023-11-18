using CustomerDetails.Models.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace CustomerDetails.Data
{
    public class CustomerDetailsContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDb");
        }

        //TODO add seeded data here?
        /*        protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Customer>().HasData(
                    new Customer {
                                Id = 1,
                                Name = "Test",
                                Age = 11,
                                Height = 1.20,
                                PostCode = "RRG 111",
                             });
                }*/

        public DbSet<Customer> Customers { get; set; }
    }
}
