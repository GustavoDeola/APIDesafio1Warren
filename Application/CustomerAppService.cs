
using Application.Models.Requests;
using Application.Models.Response;
using AutoMapper;
using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;

namespace Application
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerServices _customerService;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerServices customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CustomerResponse> GetAll(Predicate<Customer> predicate = null)
        {
            var customers = _customerService.GetAll(predicate);
            return _mapper.Map<IEnumerable<CustomerResponse>>(customers);
        }

        public CustomerResponse GetBy(Predicate<Customer> predicate)
        {
            var customer = _customerService.GetBy(predicate);
            var result = _mapper.Map<CustomerResponse>(customer);
            return result;
        }

        public int Add(CreateCustomerRequest createcustomerRequest)
        {
            var mapper = _mapper.Map<Customer>(createcustomerRequest);
            return _customerService.Add(mapper);
        }

        public bool Update(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            var customer = _mapper.Map<Customer>(updateCustomerRequest);
            customer.Id = id;
            return _customerService.Update(customer);
        }

        public bool Remove(int id)
        {
            return _customerService.Remove(id);
        }
    }
}
