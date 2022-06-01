using APIDesafioWarren.DataBase;
using APIDesafioWarren.Models;
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

        public IEnumerable<Customer> GetAll(Predicate<Customer> predicate = null)
        {
            var getAllCustomers = _customerService.GetAll(predicate);
            return _mapper.Map<IEnumerable<Customer>>(getAllCustomers);
        }

        public Customer GetBy(Predicate<Customer> predicate)
        {
            var getCustomers = _customerService.GetBy(predicate);
            var customerDTO =  _mapper.Map<Customer>(getCustomers);
            return customerDTO;
        }

        public void Add(CustomerDTO customerDTO)
        {
           var mapper = _mapper.Map<Customer>(_customerService);
            _customerService.Add(mapper);
        }

        public bool Update(int id, Customer customerChange)
        {
            var updateCustomer = _customerService.Update(id, customerChange);
            return updateCustomer;
        }

        public bool Remove(int id)
        {
           return _customerService.Remove(id); 
        }
    }
}
