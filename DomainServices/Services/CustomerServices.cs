
using Domain.Models;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var query = repository.MultipleResultQuery();
                    

            var result = repository.Search(query);

            return result;
        }

        public Customer GetBy(params Expression<Func<Customer, bool>>[] predicate)
        {
            var repository = _repositoryFactory.Repository<Customer>();

            var query = repository.SingleResultQuery();
                                  //.AndFilter(predicate);

            //var result = repository.FirstOrDefault(query);


           // return result;
            
            foreach (var item in predicate)
            {
                query.AndFilter(item);
            }

            return repository.FirstOrDefault(query);
            
            /*var customer = _context.Customers.AsNoTracking().FirstOrDefault(predicate);
            return customer;
            */
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
            var repository = _unitOfWork.Repository<Customer>();
            if (findCustomers is null && AnyCustomerForCpf(customerToUpdate)) return false;

            repository.Update(customerToUpdate);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Remove(int id)
        {
            var customer = GetBy(c => c.Id == id);
            var repository = _unitOfWork.Repository<Customer>();
            if (customer == null) return false;

            repository.Remove(customer);
            _unitOfWork.SaveChanges();

            return true;
        }

        private bool AnyCustomerForCpf(Customer customer)
        {
            var repository = _unitOfWork.Repository<Customer>();
            return repository.Any(c => c.Cpf == customer.Cpf);
        } 
    }
}
