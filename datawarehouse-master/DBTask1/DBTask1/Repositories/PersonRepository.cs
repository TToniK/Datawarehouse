using System;
using System.Collections.Generic;
using System.Text;
using DBTask1.Models;
using DBTask1.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DBTask1.Repositories
{
   
    class PersonRepository : IPersonRepository
    {
       
        private readonly Dbtask1Context _dbtask1Context = new Dbtask1Context();

        public void Create(Person person)
        {
            _dbtask1Context.Add(person);
            _dbtask1Context.SaveChanges();
        }

       
        public void CreatePerson()
        {
            Person newPerson = new Person();
            Phone newPhone = new Phone();
            Console.WriteLine("Syötä henkilön nimi: ");
            newPerson.Name = Console.ReadLine();
            Console.WriteLine("Syötä henkilön ikä: ");
            string stringAge = Console.ReadLine();
            Int16 newAge = Int16.Parse(stringAge);
            newPerson.Age = newAge;
            Console.WriteLine("Syötä puhelinnumero: ");
            newPhone.Number = Console.ReadLine();
            Console.WriteLine("Syötä tyyppi: ");
            newPhone.Type = Console.ReadLine();
            newPerson.Phone = new List<Phone>
            {
                new Phone{Type = newPhone.Type, Number = newPhone.Number},
            };

            Create(newPerson);
        }

        public List<Person> Read()
        {
            var persons = _dbtask1Context.Person
                .Include(p=>p.Phone)
                .ToList();
            return persons;
        }

        public Person Read(long id)
        {
            var readPerson = _dbtask1Context.Person.Include(p => p.Phone)
                .FirstOrDefault(p=>p.Id==id);

            if (readPerson == null)
            {
                return null;
            }
            else
            {
                return readPerson;
            }
        }

        public void Update(long id, Person person)
        {
            Console.WriteLine("Syötä henkilön muokattavan ID uudelleen: ");
            string a = Console.ReadLine();
            long b = long.Parse(a);
            var checkPerson = Read(b);
            if (checkPerson != null)
            {
                _dbtask1Context.Update(person);
                _dbtask1Context.SaveChanges();
                Console.WriteLine("Tiedot päivitetty");
            }
            else
            {
                Console.WriteLine("Tietoja ei päivitetty, ERROR!");
            }
        }

        public void UpdatePerson()
        {
            Console.WriteLine("Syötä henkilön ID, jota haluat muokata: ");
            string a = Console.ReadLine();
            long b = long.Parse(a);
            Person updatePerson = Read(b);
           
            Console.WriteLine("Syötä henkilön uusi nimi: ");
            string updated = Console.ReadLine();
            updatePerson.Id = b;
            updatePerson.Name = updated;
            Console.WriteLine("Syötä henkilön uusi ikä: ");
            string stringAge = Console.ReadLine();
            Int16 newAge = Int16.Parse(stringAge);
            updatePerson.Age = newAge;
           
            Update(b, updatePerson);
        }

        public void Delete(long id)
        {
            Console.WriteLine("Syötä Id, jonka haluat poistaa: ");
            string a = Console.ReadLine();
            long b = long.Parse(a);
            var personToDelete = Read(b);
            if (personToDelete != null)

            {
                Console.WriteLine($"{personToDelete.Name} (ID  {personToDelete.Id}) tiedot poistettu.");
                _dbtask1Context.Person.Remove(personToDelete);
                _dbtask1Context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Id ei täsmää!");
            }
        }

       

        public void DeletePerson(int id)

        {
            var person = Read(id);

            if (person == null)
            {
                Console.WriteLine($"Henkilö {id} ei löytynyt!");
            }

            else
            {
                Console.WriteLine($"Henkilö: {person.Id}, {person.Name}, {person.Phone}");
                Delete(id);
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
            }
        }
    }
}
