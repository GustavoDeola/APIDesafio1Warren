using APIDesafioWarren.Models;

namespace APIDesafioWarren.DataBase
{
    public interface ICustomerServices
    { 
        List<Customer> GetAll(Predicate<Customer> predicate = null);
        public void Add(Customer client);
        public void Update(Customer client,Customer clientChange);
        public void Remove(Customer client);
        Customer GetBy(Predicate<Customer> predicate);
    }
}
