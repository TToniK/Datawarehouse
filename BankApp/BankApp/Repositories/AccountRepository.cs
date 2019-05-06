using System;
using System.Collections.Generic;
using System.Text;
using BankApp.models;
using System.Linq;
using BankApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace BankApp.Repositories
{
    class AccountRepository : IAccounts
    {

        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void Create(Account account)
        {
            _bankdbContext.Add(account);
            _bankdbContext.SaveChanges();
        }

        public void CreateAccount(Account account)
        {
            Console.WriteLine("Luo uusi käyttäjä");
            Account newAccount = new Account();
            Console.WriteLine("Syötä käyttäjän IBAN-tilinumero: ");
            newAccount.Iban = Console.ReadLine();
            Console.WriteLine("Syötä käyttäjän nimi: ");
            newAccount.Name = Console.ReadLine();
            Console.WriteLine("Syötä pankin ID-tunnus: ");
            newAccount.BankId = Console.Read();
            Console.WriteLine("Syötä omistajan ID-tunnus: ");

            newAccount.CustomerId = Console.Read();
            newAccount.Balance = 0;
            Create(newAccount);
        }

        public void DeleteAccount(string iban)
        {
            var EliminateAccount = Read(iban);
            if (EliminateAccount != null)
            {
                Console.WriteLine($"{EliminateAccount.Name} on poistettu.");
                _bankdbContext.Account.Remove(EliminateAccount);
                _bankdbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"{iban} ei vastaa olemassa olevaa tiliä. Mitään ei poistettu.");
            }
        }
        public void Delete(string iban)
        {
            Console.WriteLine("Syötä IBAN, jonka haluat poistaa: ");
            string a = Console.ReadLine();

            var account = Read(a);
            if (account == null)
            {
                Console.WriteLine($"Käyttäjää, joka omistaisi iban-tilin: {iban}, ei löytynyt.");
            }
            else
            {
                Console.WriteLine($"{account.Name}, {account.Iban}");
                DeleteAccount(iban);
                Console.WriteLine("Tiedot on poistettu.");
            }
        }

        public List<Account> Read()
        {
            var accounts = _bankdbContext.Account.ToList();
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Name}, {account.Iban}, Omistajan ID: {account.CustomerId}, Pankin ID: {account.BankId}");
            }
            return accounts;
        }

        public Account Read(string iban)
        {

            var readIban = _bankdbContext.Account.AsNoTracking().Where(i => i.Iban == iban).FirstOrDefault();
            if (readIban == null)
            {
                return null;
            }
            else
            {
                return readIban;
            }
        }

        public void UpdateAccount(string iban, Account account)
        {

          

        }

    }
}
