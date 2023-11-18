using CustomerDetails.Models.Domain;
using CustomerDetails.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDetails.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public APIController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("customers")]
        public async Task<ActionResult<List<Customer>>> GetAll() { 
            var customers = await _customerRepository.GetAll();
            return Ok(customers);
        }
    }
}
