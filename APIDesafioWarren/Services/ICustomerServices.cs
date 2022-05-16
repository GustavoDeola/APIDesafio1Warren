using APIDesafioWarren.Models;

namespace APIDesafioWarren.DataBase
{
    public interface ICustomerServices
    {
        public List <Customer> Registers { get; set; }
        public List <Customer> GetAll(Customer client);
        public void Add(Customer client);
        public void Update(Customer client,Customer clientChange);
        public void Remove(Customer client);
         
    }
}
