using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp.models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class BankRepository : IBank

    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

       

        public void CreateBank(Bank bank)
        {
            Bank newBank = new Bank();
            Console.WriteLine("Syötä uuden pankin nimi: ");
            newBank.Name = Console.ReadLine();
            Console.WriteLine("Uuden pankin BIC-koodi: ");
            newBank.Bic = Console.ReadLine();

            Create(newBank);
            
        }

        public void Create(Bank bank)
        {
            _bankdbContext.Add(bank);
            _bankdbContext.SaveChanges();
        }

        public void DeleteBank(long id)
        {
            Console.WriteLine("Syötä ID, jonka haluat poistaa: ");
            string a = Console.ReadLine();
            long ids = long.Parse(a);
      

            var bank = GetBankById(ids);
            if (bank == null)
            {
                Console.WriteLine("Väärä Id, ei löytynyt mitään pankkia poistettavaksi");
            }
            else
            {
                Console.WriteLine($"{bank.Id}.{bank.Name}");
                Delete(ids);
                Console.WriteLine("Tiedot poistettu.");

            }
            
        }
        public void Delete(long id)
        {
           

            var bankelimination = GetBankById(id);
            if (bankelimination != null)
            {
                Console.WriteLine($"{bankelimination.Name} on poistettu.");
                _bankdbContext.Bank.Remove(bankelimination);
                _bankdbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Kyseisellä Id:llä ei löytynyt yhtään pankkia, mitään ei siis poistettu.");
            }
        }


        public Bank GetBankById(long id)
        {
            var readBank = _bankdbContext.Bank
                .FirstOrDefault(b => b.Id == id);
            if (readBank == null)
            {
                return null;
            }
            else
            {
                return readBank;
            }
        }

        public List<Bank> GetBanks()
        {
            var banks = _bankdbContext.Bank.ToList();
            foreach (var bank in banks)
            {
                Console.WriteLine($"{bank.Id}, {bank.Name}, {bank.Bic}");
            }
                return banks;
            
        }

      

        public void UpdateBank(Bank bank)
        {
            Console.WriteLine("Syötä muokattavan pankin ID: ");
            string a = Console.ReadLine();
            long id = long.Parse(a);
            Bank updateBank = GetBankById(id);
            Console.WriteLine($"Muokkaa pankin nimeä: ");
            string updated = Console.ReadLine();
            updateBank.Id = id;
            updateBank.Name = updated;
            Console.WriteLine($"Muokkaa pankin BIC-koodia: ");
            string updatedBic = Console.ReadLine();
            updateBank.Bic = updatedBic;
            Update(id, updateBank);
            
        }
        public void Update(long id, Bank bank)
        {
            var checkBank = GetBankById(id);
            if (checkBank != null)
            {
                _bankdbContext.Update(bank);
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
