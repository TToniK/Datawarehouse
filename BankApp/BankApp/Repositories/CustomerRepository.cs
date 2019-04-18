using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp.models;
using Microsoft.EntityFrameworkCore;


namespace BankApp.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void Create(Customer customer)
        {
            Customer newCustomer = new Customer();
            Console.WriteLine("Luo uusi asiakas");
            Console.WriteLine("Syötä asiakkaan etunimi: ");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Syötä asiakkaan sukunimi: ");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Syötä asiakkaan pankin id: ");
            string a = Console.ReadLine();
            long b = long.Parse(a);
            newCustomer.BankId = b;
            CreateCustomer(newCustomer);

        }
        public void CreateCustomer(Customer customer)
        {
            _bankdbContext.Add(customer);
            _bankdbContext.SaveChanges();
        }
        

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(long id)
        {
            var readCustomer = _bankdbContext.Customer.FirstOrDefault(c => c.Id == id);
            if (readCustomer == null)
            {
                return null;
            }
            else
            {
                return readCustomer;
            }
        }

        public List<Customer> GetCustomers()
        {
            var customers = _bankdbContext.Customer.ToList();
            foreach(var customer in customers)
            {
                Console.WriteLine($"{customer.Id}. {customer.FirstName} {customer.LastName}, {customer.BankId}. {customer.Bank}");
            }
            return customers;
        }

        public void Update(long id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
