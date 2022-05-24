using APIDesafioWarren.DataBase;
using APIDesafioWarren.Models;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerServices _customerServices;
        public CustomerAppService(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public List<Customer> GetAll(Predicate<Customer> predicate = null)
        {
            return _customerServices.GetAll(predicate);
        }

        public Customer GetBy(Predicate<Customer> predicate)
        {
            return _customerServices.GetBy(predicate);
        }

        public void Add(Customer customer)
        {
            _customerServices.Add(customer);
        }

        public bool Update(int id, Customer customerChange)
        {
            return _customerServices.Update(id, customerChange);
        }

        public bool Remove(int id)
        {
           return _customerServices.Remove(id); 
        }
    }
}
