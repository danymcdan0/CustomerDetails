using CustomerDetails.Models.Domain;

namespace CustomerDetails.Repository
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAll();
    }
}
