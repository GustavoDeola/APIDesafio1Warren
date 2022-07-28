
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services
{
    public interface ICustomerServices
    { 
        IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicate = null);
        public int Add(Customer customer);
        public bool Update(Customer customerToUpdate);
        public bool Remove(int id);
        Customer GetBy(params Expression<Func<Customer, bool>>[] predicate);
    }
}
