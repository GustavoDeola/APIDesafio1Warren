using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs
{
    public class CustomerDTO
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public int idade { get; set; }
        public DateTime Birthdate { get; set; }
        public string CellPhone { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
    }
}
