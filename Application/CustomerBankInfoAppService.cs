using Application.Models.Requests;
using Application.Models.Response;
using AutoMapper;
using Domain.Models;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CustomerBankInfoAppService : ICustomerBankInfoAppService
    {
        private readonly ICustomerBankInfoServices _customerBankInfoServices;
        private readonly IMapper _mapper;

        public CustomerBankInfoAppService(ICustomerBankInfoServices customerBankInfoServices, IMapper mapper)
        {
            _customerBankInfoServices = customerBankInfoServices ?? throw new ArgumentNullException(nameof(customerBankInfoServices
                ));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CustomerBankInfoResponse> GetAll(Expression<Func<CustomerBankInfo, bool>> predicate = null)
        {
            var accounts = _customerBankInfoServices.GetAll(predicate);
            return _mapper.Map<IEnumerable<CustomerBankInfoResponse>>(accounts);
        }

        public CustomerBankInfoResponse GetBy(Expression<Func<CustomerBankInfo, bool>> predicate)
        {
            var accounts = _customerBankInfoServices.GetBy(predicate);
            var result = _mapper.Map<CustomerBankInfoResponse>(accounts);
            return result;
        }

        public int Add(CreateCustomerBankInfoRequest createCustomerBankInfoRequest)
        {
            var mapper = _mapper.Map<CustomerBankInfo>(createCustomerBankInfoRequest);
            return _customerBankInfoServices.Add(mapper);
        }

        public bool Update(int id, UpdateCustomerBankInfoRequest updateCustomerBankInfoRequest)
        {
            var bankInfo = _mapper.Map<CustomerBankInfo>(updateCustomerBankInfoRequest);
            bankInfo.Id = id;
            return _customerBankInfoServices.Update(bankInfo);
        }

        public bool Remove(int id)
        {
            return _customerBankInfoServices.Remove(id);
        }
    }
}


