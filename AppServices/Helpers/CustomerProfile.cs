using APIDesafioWarren.Models;
using Application.Models.DTOs;
using AutoMapper;


namespace AppServices.Helpers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();

        }
    }
}
