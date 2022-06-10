using APIDesafioWarren.Models;
using App.Services;
using Application.Models.DTOs;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResponse> GetAll(Predicate<Customer> predicate = null);
        public int Add(CreateCustomerRequest createCustomerRequest);
        public bool Update(CustomerResponse customerResponseUpdated);
        public bool Remove(int id);
        Customer GetBy(Predicate<Customer> predicate);
    }
}
