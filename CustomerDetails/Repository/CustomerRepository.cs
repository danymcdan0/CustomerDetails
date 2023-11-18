using CustomerDetails.Data;
using CustomerDetails.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerDetails.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository() {
            using (var context = new CustomerDetailsContext())
            {
                var customers = new List<Customer>
                {
                    new Customer
                    {
                        Name = "Test",
                        Age = 11,
                        Height = 1.20,
                        PostCode = "RRG 111",
                    },
                    new Customer
                    {
                        Name = "Test2",
                        Age = 21,
                        Height = 2.10,
                        PostCode = "111 RRG",
                    }
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            using (var context = new CustomerDetailsContext()) {
                var list = await context.Customers.ToListAsync();
                return list;
            }
        }
    }
}
