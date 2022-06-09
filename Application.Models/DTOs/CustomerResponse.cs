using System;

namespace Application.Models.DTOs
{
    public class CustomerResponse
    {
        //Response
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
       
    }
}
