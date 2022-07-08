using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Services
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
