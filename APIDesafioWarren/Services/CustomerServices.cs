using APIDesafioWarren.Models;

namespace APIDesafioWarren.DataBase
{
    public class CustomerServices : ICustomerServices
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public List<Customer> GetAll(Predicate<Customer> predicate = null)
        {
            return predicate is null
                ? _customers
                : _customers.FindAll(predicate);
        }

        public Customer GetBy(Predicate<Customer> predicate)
        {    
            var customer = _customers.Find(predicate);
            return customer;
        }

        public void Add(Customer customer)
        {
            int incrementId = _customers.LastOrDefault()?.Id ?? default;
           
            customer.Id = incrementId + 1;
            _customers.Add(customer);
        }

        public void Update(Customer customer, Customer customerChange)
        {
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
        }

        public void Remove(Customer customer)
        {
            _customers.Remove(customer);
        }
    }
}
