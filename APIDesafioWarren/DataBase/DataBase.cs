using APIDesafioWarren.Models;

namespace APIDesafioWarren.DataBase
{
    public class DataBase : IDataBase
    {
        public readonly IDataBase _database;

        public List<ClientRegister> Registers { get; set; } = new List<ClientRegister>()
        {
            new ClientRegister()
            {
                Id = 1,
                fullName = "Gustavo Cabral Deola",
                email = "gustavocabral@gmail.com",
                emailConfirmation = "gustavocabral@gmail.com",
                birthdate = DateTime.Parse("2004/12/16"),
                cpf = "093.765.432-67",
                cellphone = "47999171412",
                emailSms = true,
                Whatsapp = false,
                country = "Brazil",
                city = "Blumenau",
                postalCode = "5456775342",
                address = "Rua Paraguai Gonçalves",
                number = "250"
            }
        };
        public List<ClientRegister> showRegisters { get; set; } = new List<ClientRegister>()
        {
            new ClientRegister(){
                Id = 2,
                fullName = "Gustavo Cabral Deola",
                email = "gustavocabral@gmail.com",
                emailConfirmation = "gustavocabral@gmail.com",
                birthdate = DateTime.Parse("2004/12/16"),
                cpf = "093.765.432-67",
                cellphone = "47999171412",
                emailSms = true,
                Whatsapp = false,
                country = "Brazil",
                city = "Blumenau",
                postalCode = "5456775342",
                address = "Rua Paraguai Gonçalves",
                number = "250"
            }
        };
            
         

          
        public void add(ClientRegister client)
        {
            int incrementId = Registers.Last().Id;
            client.Id = incrementId +1;
            Registers.Add(client);
        }

     
        public void refresh(ClientRegister client, ClientRegister clientChange)
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

        public void remove(ClientRegister client)
        {

            Registers.Remove(client);
        }

    }
}
