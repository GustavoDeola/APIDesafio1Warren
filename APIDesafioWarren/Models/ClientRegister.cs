namespace APIDesafioWarren.Models
{
    public class ClientRegister
    {


        public ClientRegister() { }

        public ClientRegister(int id, string fullname, string email, string emailconfirmation, string cpf, string cellphone, DateTime birthdate, bool emailSms, bool Whatsapp, string country, string city, string postalcode, string address, int number)
        {
            this.Id = id;
            this.fullName = fullName;
            this.email = email;
            this.emailConfirmation = email;
            this.cpf = cpf;
            this.cellphone = cellphone;
            this.birthdate = birthdate;
            this.emailSms = emailSms;
            this.Whatsapp = Whatsapp;
            this.country = country;
            this.city = city;
            this.postalCode = postalcode;
            this.address = address;
            this.number = number;

        }
        public int Id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string emailConfirmation { get; set; }
        public string cpf { get; set; }
        public string cellphone  { get; set; }
        public DateTime birthdate { get; set; }
        public bool emailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string country  { get; set; }
        public string city { get; set; }
        public string postalCode{ get; set; }
        public string  address { get; set; }
        public int  number { get; set; }

    }
}
