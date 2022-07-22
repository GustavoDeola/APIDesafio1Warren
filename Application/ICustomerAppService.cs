using Application;
using Application.Models.Requests;
using Application.Models.Response;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResponse> GetAll(Func<Customer, bool> predicate = null);
        public int Add(CreateCustomerRequest createCustomerRequest);
        public bool Update(int id, UpdateCustomerRequest updateCustomerRequest);
        public bool Remove(int id);
        CustomerResponse GetBy(Func<Customer, bool> predicate);
    }
}
