using System;
using System.Collections.Generic;
using System.Text;
using BankApp.models;
using BankApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankApp.Repositories
{
    class TransactionRepository : ITransaction

    {
        static AccountRepository accountRepository = new AccountRepository();
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        

        public List<Transaction> GetTransactions()
        {
            var transactions = _bankdbContext.Transaction.ToList();
            foreach(var transaction in transactions)
            {
                Console.WriteLine($"{transaction.Iban}, {transaction.Amount}€, {transaction.TimeStamp}");
            }
            return transactions;
        }
        
    }
}
