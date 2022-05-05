using APIDesafioWarren.Models;

namespace APIDesafioWarren.DataBase
{
    public interface IDataBase
    {
        public List <ClientRegister> Registers { get; set; }

        public List <ClientRegister> showRegisters { get; set; }

        public void add(ClientRegister client);

        public void refresh(ClientRegister client,ClientRegister clientChange);

        public void remove(ClientRegister client);
       
      
        
    }



}
