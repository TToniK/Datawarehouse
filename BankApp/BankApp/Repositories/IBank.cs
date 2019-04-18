using BankApp.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Repositories
{
    internal interface IBank
    {
        //CRUD
        List<Bank> GetBanks();
        
        Bank GetBankById(long id);
        void CreateBank(Bank bank);
        void Create(Bank bank);
        void UpdateBank(Bank bank);
        void Update(long id, Bank bank);
        void DeleteBank(long id);
        void Delete(long id);

    }
}
