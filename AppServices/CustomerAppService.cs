using APIDesafioWarren.DomainService;
using APIDesafioWarren.Models;
using App.Services;
using Application.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AppServices
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
            var getAllCustomers = _customerService.GetAll(predicate);
            return _mapper.Map<IEnumerable<CustomerResponse>>(getAllCustomers);
        }

        public Customer GetBy(Predicate<Customer> predicate)
        {
            var getCustomers = _customerService.GetBy(predicate);
            var customerDTO = _mapper.Map<Customer>(getCustomers);
            return customerDTO;
        }

        public int Add(CreateCustomerRequest createcustomerRequest)
        {
            var mapper = _mapper.Map<Customer>(createcustomerRequest);
            //_customerService.Add(mapper);
            //return mapper.Id;
            return _customerService.Add(mapper);
        }

        public bool Update(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            var mapper = _mapper.Map<Customer>(updateCustomerRequest);
            mapper.Id = id;
            return _customerService.Update(mapper);
        }

        public bool Remove(int id)
        {
            return _customerService.Remove(id);
        }
    }
}
