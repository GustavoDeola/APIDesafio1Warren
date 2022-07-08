using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly List<Customer> _customers = new();

        public List<Customer> GetAll(Predicate<Customer> predicate = null)
        {
            if (predicate is null)
            {
                return _customers;
            }
            var customers = _customers.FindAll(predicate);

            return customers.Count is 0
                ? null
                : customers;
        }

        public Customer GetBy(Predicate<Customer> predicate)
        {
            var customer = _customers.Find(predicate);
            return customer;
        }

        public int Add(Customer customer)
        {
            int incrementId = _customers.LastOrDefault()?.Id ?? default;

            if (AnyCustomerForCpf(customer)) return -1;

            customer.Id = incrementId + 1;
            _customers.Add(customer);
           
            return customer.Id;
        }

        public bool Update(Customer customerChange)
        {
            var findCustomers = _customers.FindIndex(c => c.Id == customerChange.Id);
            if (findCustomers == -1) return false;

            _customers[findCustomers] = customerChange;
            return true;
        }

        public bool Remove(int id)
        {
            var customer = GetBy(c => c.Id == id);
            if (customer is null) return false;
            _customers.Remove(customer);
            return true;
        }

        private bool AnyCustomerForCpf(Customer customer)
        {
            return _customers.Any(c => c.Cpf == customer.Cpf);
        } 
    }
}
