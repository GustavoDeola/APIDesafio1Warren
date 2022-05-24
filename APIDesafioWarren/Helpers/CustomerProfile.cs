using APIDesafioWarren.Models;
using AutoMapper;
using Domain_Models.Dtos;

namespace APIDesafioWarren.Helpers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
                    
        }
    }
}
