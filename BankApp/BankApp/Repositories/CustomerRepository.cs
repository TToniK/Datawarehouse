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


        public void DeleteCustomer(long id)
        {
            Console.WriteLine("Syötä ID, jonka haluat poistaa: ");
            string a = Console.ReadLine();
            long ids = long.Parse(a);


            var customer = GetCustomer(ids);
            if (customer == null)
            {
                Console.WriteLine("Väärä Id, ei löytynyt ketään henkilöä poistettavaksi");
            }
            else
            {
                Console.WriteLine($"{customer.Id}.{customer.FirstName}, {customer.LastName}");
                Delete(ids);
                Console.WriteLine("Tiedot poistettu.");

            }

        }
        public void Delete(long id)
        {


            var customerElimination = GetCustomer(id);
            if (customerElimination != null)
            {
                Console.WriteLine($"{customerElimination.FirstName} {customerElimination.LastName} on poistettu.");
                _bankdbContext.Customer.Remove(customerElimination);
                _bankdbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Kyseisellä Id:llä ei löytynyt yhtään henkilöä, mitään ei siis poistettu.");
            }
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
                
                if (customer.BankId == 1)
                {
                    Console.WriteLine($"{customer.Id}. {customer.FirstName} {customer.LastName}, {customer.BankId} Nordea.");
                }
                else if (customer.BankId == 2)
                {
                    Console.WriteLine($"{customer.Id}. {customer.FirstName} {customer.LastName}, {customer.BankId} Op.");
                }
                else if (customer.BankId == 3)
                {
                    Console.WriteLine($"{customer.Id}. {customer.FirstName} {customer.LastName}, {customer.BankId} Säästöpankki");
                }
                else
                {
                    Console.WriteLine($"{customer.Id}. {customer.FirstName} {customer.LastName}, {customer.BankId} (Tarkista pankin nimi listalta.)");
                }
            }
            return customers;
        }

        public void UpdateCustomer(Customer customer)
        
        {
            Console.WriteLine("Syötä muokattavan henkilön ID: ");
            string a = Console.ReadLine();
            long b = long.Parse(a);
            Customer updateCustomer = GetCustomer(b);
            Console.WriteLine($"Muokkaa etunimeä: ");
            string updateda = Console.ReadLine();
            updateCustomer.Id = b;
            updateCustomer.FirstName = updateda;
            Console.WriteLine($"Muokkaa sukunimeä: ");
            string updatedb = Console.ReadLine();
            updateCustomer.LastName = updatedb;
            Console.WriteLine($"Muokkaa henkilön pankin Id:tä: ");
            string updatedId = Console.ReadLine();
            long newId = long.Parse(updatedId);
            updateCustomer.BankId = newId;
            Update(b, updateCustomer);

        }
        public void Update(long id, Customer customer)
        {
            var checkCustomer = GetCustomer(id);
            if (checkCustomer != null)
            {
                _bankdbContext.Update(customer);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot päivitetty.");
            }
            else
            {
                Console.WriteLine("Pahus, jokin meni pieleen!");
            }

        }
    }
}
