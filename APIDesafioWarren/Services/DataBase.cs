using APIDesafioWarren.Models;

namespace APIDesafioWarren.DataBase
{
    public class DataBase : IDataBase
    {
        public readonly IDataBase _database;

        public List<ClientRegister> Registers { get; set; } = new List<ClientRegister>();
          
        public void Add(ClientRegister client)
        {
            int incrementId = Registers.LastOrDefault()?.Id ?? default;
           
            client.Id = incrementId +1;
            Registers.Add(client);
        }

     
        public void Update(ClientRegister client, ClientRegister clientChange)
        {
            clientChange.fullName = client.fullName;
            clientChange.email = client.email;
            clientChange.emailConfirmation = client.emailConfirmation;
            clientChange.cpf = client.cpf;
            clientChange.emailSms = client.emailSms;
            clientChange.cellphone = client.cellphone;
            clientChange.country = client.country;
            clientChange.city = client.city;
            clientChange.postalCode = client.postalCode;
            clientChange.address = client.address;
            clientChange.number = client.number;
            clientChange.Whatsapp = client.Whatsapp;
            
                
        }

        public void Remove(ClientRegister client)
        {

            Registers.Remove(client);
        }

    }
}
