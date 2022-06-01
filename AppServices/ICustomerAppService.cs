using APIDesafioWarren.Models;
using Application.Models.DTOs;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public interface ICustomerAppService
    {
        IEnumerable<Customer> GetAll(Predicate<Customer> predicate = null);
        public void Add(CustomerDTO customerDTO);
        public bool Update(int id, Customer customerChange);
        public bool Remove(int id);
        Customer GetBy(Predicate<Customer> predicate);
    }
}
