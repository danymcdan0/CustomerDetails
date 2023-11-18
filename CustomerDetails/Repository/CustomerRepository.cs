using CustomerDetails.Data;
using CustomerDetails.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerDetails.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
/*        public CustomerRepository() {
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
        }*/

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            using (var context = new CustomerDetailsContext()) {
                var list = await context.Customers.ToListAsync();
                return list;
            }
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            using (var context = new CustomerDetailsContext())
            {
                var targetCustomer = await context.Customers.SingleOrDefaultAsync(x => x.Id == id);
                return targetCustomer;
            }
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            using (var context = new CustomerDetailsContext())
            {
                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
                return customer;
            }
        }

        public async Task<Customer> EditCustomerAsync(int id, Customer customer)
        {
            using (var context = new CustomerDetailsContext())
            {
                var targetCustomer = await context.Customers.SingleOrDefaultAsync(x => x.Id == id);
                targetCustomer.Name = customer.Name;
                targetCustomer.Age = customer.Age;
                targetCustomer.Height  = customer.Height;
                targetCustomer.PostCode = customer.PostCode;

                await context.SaveChangesAsync();

                return customer;
            }
        }
    }
}
