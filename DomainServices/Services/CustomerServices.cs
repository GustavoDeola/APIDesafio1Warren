
using Domain.Models;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly Context _context;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepositoryFactory _repositoryFactory;
        public CustomerServices(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        public IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null)
        {
            var repository = _repositoryFactory.Repository<Customer>();

            var query = repository.MultipleResultQuery();

            var result = repository.Search(query);

            return result;

            /*if (predicate is null) return _context.Customers;

            var customers = _context.Customers.Where(predicate);
            return customers;
            */
        }

        public Customer GetBy(Func<Customer, bool> predicate)
        {
            var customer = _context.Customers.AsNoTracking().FirstOrDefault(predicate);
            return customer;
        }

        public int Add(Customer customer)
        {
            if (AnyCustomerForCpf(customer)) return -1;

            _context.Customers.Add(customer);

            _context.SaveChanges();
            return customer.Id;
        }

        public bool Update(Customer customerToUpdate)
        {
            var findCustomers = GetBy(c => c.Id == customerToUpdate.Id);
            if (findCustomers is null && AnyCustomerForCpf(customerToUpdate)) return false;

            _context.Customers.Update(customerToUpdate);
            _context.SaveChanges();
            return true;
        }

        public bool Remove(int id)
        {
            var customer = GetBy(c => c.Id == id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return true;
        }

        private bool AnyCustomerForCpf(Customer customer)
        {
            return _context.Customers.Any(c => c.Cpf == customer.Cpf);
        } 
    }
}
