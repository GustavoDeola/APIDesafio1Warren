using APIDesafioWarren.Models;

namespace APIDesafioWarren.DataBase
{
    public interface IDataBase
    {
        public List <ClientRegister> Registers { get; set; }

        public void Add(ClientRegister client);

        public void Update(ClientRegister client,ClientRegister clientChange);

        public void Remove(ClientRegister client);
       
      
        
    }



}
