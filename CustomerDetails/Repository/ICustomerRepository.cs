using CustomerDetails.Models.Domain;

namespace CustomerDetails.Repository
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomerAsync();

        public Task<Customer> CreateCustomerAsync(Customer customer);
        public Task<Customer> EditCustomerAsync(int id, Customer customer);
    }
}
