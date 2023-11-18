using AutoMapper;
using CustomerDetails.Models.Domain;
using CustomerDetails.Models.DTO;

namespace CustomerDetails
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
