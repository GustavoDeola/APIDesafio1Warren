using Domain.Models;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;

        public CustomerServices(IUnitOfWork<Context> unitOfWork, IRepositoryFactory<Context> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> predicate = null)
        {
            var repository = _repositoryFactory.Repository<Customer>();

            var query = repository.MultipleResultQuery()
                                  .AndFilter(predicate);

            return repository.Search(query);
        }

        public Customer GetBy(Expression<Func<Customer, bool>> predicate)
        {
            var repository = _repositoryFactory.Repository<Customer>();

            var query = repository.SingleResultQuery()
                                  .AndFilter(predicate);

            return repository.FirstOrDefault(query);
        }

        public int Add(Customer customer)
        {
            if (AnyCustomerForCpf(customer)) return -1;

            var repository = _unitOfWork.Repository<Customer>();

            repository.Add(customer);

            _unitOfWork.SaveChanges();
            return customer.Id;
        }

        public bool Update(Customer customerToUpdate)
        {
            var findCustomers = GetBy(c => c.Id == customerToUpdate.Id);
            if (findCustomers is null && AnyCustomerForCpf(customerToUpdate)) return false;
            
            var repository = _unitOfWork.Repository<Customer>();

            repository.Update(customerToUpdate);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Remove(int id)
        {
            var customer = GetBy(c => c.Id == id);
            var repository = _unitOfWork.Repository<Customer>();
            
            return repository.Remove(x => x.Id.Equals(id)) > 0;
            _unitOfWork.SaveChanges();

            return true;
        }

        private bool AnyCustomerForCpf(Customer customer)
        {
            var repository = _repositoryFactory.Repository<Customer>();
            return repository.Any(c => c.Cpf == customer.Cpf);
        } 
    }
}
