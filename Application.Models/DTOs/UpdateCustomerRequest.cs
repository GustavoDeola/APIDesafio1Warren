using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class UpdateCustomerRequest 
    {
        private readonly List<CustomerResponse>  _customerResponse = new List<CustomerResponse>();
        
        public bool Update(CustomerResponse customerDTOChange, CustomerResponse customerResponse)
        {
            var customerFind = _customerResponse.FindIndex(c => c.Equals(c.Id));

            if (customerFind is 0) return false;

             customerDTOChange.FullName = customerResponse.FullName;
             customerDTOChange.Email = customerResponse.Email;
             customerDTOChange.Cpf = customerResponse.Cpf;
             customerDTOChange.Country = customerResponse.Country;
             customerDTOChange.City = customerResponse.City;

            //_customerResponse[customerResponse] = customerDTOChange;
            return true;
        }
    }
}
