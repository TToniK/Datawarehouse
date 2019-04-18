using System;
using System.Collections.Generic;
using System.Text;
using BankApp.models;

namespace BankApp.Repositories
{
    interface ICustomerRepository
    {
        void Create(Customer customer);
        List<Customer> GetCustomers();
        Customer GetCustomer(long id);
        void Update(long id, Customer customer);
        void Delete(long id);
    }
}
