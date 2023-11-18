using AutoMapper;
using CustomerDetails.Models.Domain;
using CustomerDetails.Models.DTO;
using CustomerDetails.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDetails.Controller
{
    [Route("api/")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;

        public APIController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("customer")]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomerAsync() { 
            var customers = await _customerRepository.GetAllCustomerAsync();
            var customersDTO = _mapper.Map<List<CustomerDTO>>(customers);
            return Ok(customersDTO);
        }

        [HttpGet]
        [Route("customer/{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerAsync(int id)
        {
            var customers = await _customerRepository.GetCustomerAsync(id);
            var customersDTO = _mapper.Map<CustomerDTO>(customers);
            return Ok(customersDTO);
        }

        [HttpPost]
        [Route("customer")]
        public async Task<ActionResult<CustomerDTO>> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.CreateCustomerAsync(customer);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(customerDTO);
        }

        [HttpPut]
        [Route("customer/{id}")]
        public async Task<ActionResult<CustomerDTO>> EditCustomerAsync([FromRoute] int id, CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.EditCustomerAsync(id, customer);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(customerDTO);
        }
    }
}
