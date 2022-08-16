using Application.Models.Requests;
using Application.Models.Response;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class CustomerBankInfoProfile : Profile
    {
        public CustomerBankInfoProfile()
        {
            CreateMap<CreateCustomerBankInfoRequest, CustomerBankInfo>();
            CreateMap<CustomerBankInfo, CustomerBankInfoResponse>();
            CreateMap<UpdateCustomerBankInfoRequest, CustomerBankInfo>();
        }
    }
}
