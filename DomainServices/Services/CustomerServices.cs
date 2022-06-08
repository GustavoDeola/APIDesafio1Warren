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
            var findCustomers = _customersServices.FindAll(predicate);

            return findCustomers.Count is 0
                ? null
                : findCustomers;
        }

        public Customer GetBy(Predicate<Customer> predicate)
        {    
            var customer = _customersServices.Find(predicate);
            return customer;
        }

        public void Add(Customer customer)
        {
            int incrementId = _customersServices.LastOrDefault()?.Id ?? default;
           
            customer.Id = incrementId + 1;
            _customersServices.Add(customer);
        }

        public bool Update(Customer customerChange)
        {
            var customer = GetBy(c => c.Id == customerChange.Id);

            if (customer is null) return false;
            
            customerChange.FullName = customer.FullName;
            customerChange.Email = customer.Email;
            customerChange.EmailConfirmation = customer.EmailConfirmation;
            customerChange.Cpf = customer.Cpf;
            customerChange.EmailSms = customer.EmailSms;
            customerChange.Cellphone = customer.Cellphone;
            customerChange.Country = customer.Country;
            customerChange.City = customer.City;
            customerChange.PostalCode = customer.PostalCode;
            customerChange.Address = customer.Address;
            customerChange.Number = customer.Number;
            customerChange.Whatsapp = customer.Whatsapp;
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
