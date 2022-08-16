using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface ICustomerBankInfoServices
    {
        IEnumerable<CustomerBankInfo> GetAll(Expression<Func<CustomerBankInfo, bool>> predicate = null);
        public int Add(CustomerBankInfo customerBankInfo);
        public bool Update(CustomerBankInfo customerBankInfoToUpdate);
        public bool Remove(int id);
        CustomerBankInfo GetBy(Expression<Func<CustomerBankInfo, bool>> predicate);
    }
}
