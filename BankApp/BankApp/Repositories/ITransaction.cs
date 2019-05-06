using System;
using System.Collections.Generic;
using System.Text;
using BankApp.models;

namespace BankApp.Repositories
{
    interface ITransaction
    {
        List<Transaction> GetTransactions();
        
    }
}
