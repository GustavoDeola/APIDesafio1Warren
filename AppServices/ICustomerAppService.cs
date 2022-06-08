using APIDesafioWarren.Models;
using Application.Models.DTOs;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResponse> GetAll(Predicate<Customer> predicate = null);
        public void Add(CustomerResponse customerDTO);
        public bool Update(CustomerResponse customerDTOChange);
        public bool Remove(int id);
        Customer GetBy(Predicate<Customer> predicate);
    }
}
