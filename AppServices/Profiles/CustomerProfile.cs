using APIDesafioWarren.Models;
using Application.Models.Requests;
using AutoMapper;
using Application.Models.Response;

namespace Application.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<Customer, CustomerResponse>();
            CreateMap<UpdateCustomerRequest, Customer>();
        }
    }
}