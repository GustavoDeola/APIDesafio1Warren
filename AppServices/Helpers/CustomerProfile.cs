using APIDesafioWarren.Models;
using App.Services;
using Application.Models.DTOs;
using AutoMapper;


namespace AppServices.Helpers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<CustomerResponse, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();

        }
    }
}
