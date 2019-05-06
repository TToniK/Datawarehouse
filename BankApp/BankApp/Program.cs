using System;
using BankApp.models;
using BankApp.Repositories;
using System.Globalization;


namespace BankApp
{
    class Program
    {
        static BankRepository bankRepository = new BankRepository();
        static CustomerRepository customerRepository = new CustomerRepository();
        static AccountRepository accountRepository = new AccountRepository();
        static TransactionRepository transactionRepository = new TransactionRepository();
        private static Bank bank;
        private static Customer customer;
        private static Account account;
        private static string iban;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("fi-FI");
            Console.WriteLine("Tämä on Tietokannat 2019 harjoitustyö");
            ////bankRepository.CreateBank(bank);
            //bankRepository.GetBanks();
            ////bankRepository.UpdateBank(bank);
            ////bankRepository.GetBanks();
            ////bankRepository.DeleteBank(1);
            //customerRepository.Create(customer);
            //customerRepository.GetCustomers();
            //customerRepository.UpdateCustomer(customer);
            //customerRepository.GetCustomers();
            //customerRepository.DeleteCustomer(1);
            //customerRepository.GetCustomers();
            //accountRepository.Read();
            //accountRepository.CreateAccount(account);
            ////accountRepository.Read();
            //accountRepository.Delete(iban);
            //accountRepository.Read();
            transactionRepository.GetTransactions();
           


            Console.ReadKey();
        }
    }
}
