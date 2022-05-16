using APIDesafioWarren.Models;

namespace APIDesafioWarren.DataBase
{
    public class CustomerServices : ICustomerServices
    {
        public readonly ICustomerServices _database;
        public List<Customer> Registers { get; set; } = new List<Customer>();

        public List<Customer> GetAll(Customer customer)
        {
            return Registers.FindAll(c => c.Equals(customer));
        }
        public void Add(Customer customer)
        {
            int incrementId = Registers.LastOrDefault()?.Id ?? default;
           
            customer.Id = incrementId +1;
            Registers.Add(customer);
            
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
            Registers.Remove(customer);
        }

    }
}
