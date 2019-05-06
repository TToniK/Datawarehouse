using System;
using System.Collections.Generic;
using System.Text;
using BankApp.models;

namespace BankApp.Repositories
{
    interface IAccounts
    {
        void CreateAccount(Account account);
        List<Account> Read();
        Account Read(string iban);
        void UpdateAccount(string iban, Account account);
        void DeleteAccount(string iban);
    }
}
