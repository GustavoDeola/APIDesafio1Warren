using APIDesafioWarren.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIDesafioWarren.DataBase
{
    public class CustomerServices : ICustomerServices
    {
        private readonly List<Customer> _customersServices = new List<Customer>();

        public List<Customer> GetAll(Predicate<Customer> predicate = null)
        {
            if (predicate is null)
            {
                return _customersServices;
            }
            var customers = _customersServices.FindAll(predicate);

            return customers.Count is 0
                ? null
                : customers;
        }

        public Customer GetBy(Predicate<Customer> predicate)
        {
            var customer = _customersServices.Find(predicate);
            return customer;
        }

        public int Add(Customer customer)
        {
            int incrementId = _customersServices.LastOrDefault()?.Id ?? default;

            customer.Id = incrementId + 1;
            _customersServices.Add(customer);
            return customer.Id;
        }

        public bool Update(Customer customerChange)
        {
            var findCustomers = _customersServices.FindIndex(c => c.Id == customerChange.Id);
            if (findCustomers == -1) return false;

            _customersServices[findCustomers] = customerChange;
            return true;
        }

        public bool Remove(int id)
        {
            var cli = GetBy(c => c.Id == id);
            if (cli is null) return false;

            _customersServices.Remove(cli);
            return true;
        }
    }
}
