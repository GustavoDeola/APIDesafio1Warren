using APIDesafioWarren.Models;
using App.Services;
using Application.Models.DTOs;
using AutoMapper;
using System.Collections.Generic;

namespace AppServices.Helpers
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
