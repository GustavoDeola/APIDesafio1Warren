
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public interface ICustomerServices
    { 
        IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null);
        public int Add(Customer customer);
        public bool Update(Customer customerToUpdate);
        public bool Remove(int id);
        Customer GetBy(Func<Customer, bool> predicate);
    }
}
