﻿using APIDesafioWarren.Models;
using System;
using System.Collections.Generic;

namespace APIDesafioWarren.DataBase
{
    public interface ICustomerServices
    { 
        List<Customer> GetAll(Predicate<Customer> predicate = null);
        public void Add(Customer client);
        public bool Update(int id, Customer clientChange);
        public bool Remove(int id);
        Customer GetBy(Predicate<Customer> predicate);
    }
}