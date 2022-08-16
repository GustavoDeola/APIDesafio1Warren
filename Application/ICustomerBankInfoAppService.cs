using Application.Models.Requests;
using Application.Models.Response;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICustomerBankInfoAppService
    {
        IEnumerable<CustomerBankInfoResponse> GetAll(Expression<Func<CustomerBankInfo, bool>> predicate = null);
        public int Add(CreateCustomerBankInfoRequest createCustomerBankInfoRequest);
        public bool Update(int id, UpdateCustomerBankInfoRequest customerBankInfoToUpdate);
        public bool Remove(int id);
        CustomerBankInfoResponse GetBy(Expression<Func<CustomerBankInfo, bool>> predicate);
    }
}
