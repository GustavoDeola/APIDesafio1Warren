using Application;
using Application.Models.Requests;
using Application.Models.Response;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResponse> GetAll(Expression<Func<Customer, bool>> predicate = null);
        public int Add(CreateCustomerRequest createCustomerRequest);
        public bool Update(int id, UpdateCustomerRequest updateCustomerRequest);
        public bool Remove(int id);
        CustomerResponse GetBy(params Expression<Func<Customer, bool>>[] predicate);
    }
}
