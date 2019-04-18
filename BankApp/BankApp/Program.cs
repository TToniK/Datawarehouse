using System;
using BankApp.models;
using BankApp.Repositories;


namespace BankApp
{
    class Program
    {
        static BankRepository bankRepository = new BankRepository();
        static CustomerRepository customerRepository = new CustomerRepository();
        private static Bank bank;
        private static Customer customer;

        static void Main(string[] args)
        {
            Console.WriteLine("Tämä on Tietokannat 2019 harjoitustyö");
            //bankRepository.CreateBank(bank);
            //bankRepository.GetBanks();
            //bankRepository.UpdateBank(bank);
            //bankRepository.GetBanks();
            //bankRepository.DeleteBank(1);
            customerRepository.Create(customer);
            customerRepository.GetCustomers();

            Console.ReadKey();
        }
    }
}
