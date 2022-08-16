using Domain.Models;
using Domain.Services.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class CustomerBankInfoServices : ICustomerBankInfoServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;

        public CustomerBankInfoServices(IUnitOfWork<Context> unitOfWork, IRepositoryFactory<Context> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        public IEnumerable<CustomerBankInfo> GetAll(Expression<Func<CustomerBankInfo, bool>> predicate = null)
        {
            var repository = _repositoryFactory.Repository<CustomerBankInfo>();

            var query = repository.MultipleResultQuery()
                                  .AndFilter(predicate);

            return repository.Search(query);
        }

        public CustomerBankInfo GetBy(Expression<Func<CustomerBankInfo, bool>> predicate)
        {
            var repository = _repositoryFactory.Repository<CustomerBankInfo>();

            var query = repository.SingleResultQuery()
                                  .AndFilter(predicate);

            return repository.FirstOrDefault(query);
        }

        public int Add(CustomerBankInfo customerBankInfo)
        {
            var repository = _unitOfWork.Repository<CustomerBankInfo>();

            repository.Add(customerBankInfo);

            _unitOfWork.SaveChanges();
            return customerBankInfo.Id;
        }

        public bool Update(CustomerBankInfo customerBankInfoToUpdate)
        {
            var findAccounts = GetBy(c => c.Id == customerBankInfoToUpdate.Id);
            if (findAccounts is null) return false;

            var repository = _unitOfWork.Repository<CustomerBankInfo>();

            repository.Update(customerBankInfoToUpdate);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Remove(int id)
        {
            var repository = _unitOfWork.Repository<CustomerBankInfo>();

            return repository.Remove(x => x.Id.Equals(id)) > 0;

            return true;
        }
    }
}
