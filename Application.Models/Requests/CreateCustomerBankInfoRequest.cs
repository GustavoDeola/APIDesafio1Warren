using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class CreateCustomerBankInfoRequest
    { 
        public string Account { get; set; }
        public decimal AccountBalance { get; set; }
        public int CustomerId { get; set;}
    }
}
