using APIDesafioWarren.Models;
using System;
using System.Collections.Generic;

namespace APIDesafioWarren.DomainService
{
    public interface ICustomerServices
    { 
        List<Customer> GetAll(Predicate<Customer> predicate = null);
        public int Add(Customer customer);
        public bool Update(Customer customerToUpdate);
        public bool Remove(int id);
        Customer GetBy(Predicate<Customer> predicate);
    }
}
