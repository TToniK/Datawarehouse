using System;
using System.Collections.Generic;
using System.Text;
using Person_Phone.Models;
using Person_Phone.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Linq;
using System.Data.SqlClient;


namespace Person_Phone.Repositories
{
    class Person_PhoneRepositories : IPerson_Phone
    {
        private Models.Person_Phone _person_PhoneContext;


        public Person_PhoneRepositories(Models.Person_Phone person_PhoneContext)
        {
            this._person_PhoneContext = person_PhoneContext;
        }

        public Person_PhoneRepositories()
        {
        }
        public void Create(Person person)
        {
            _person_PhoneContext.Add(person);
            _person_PhoneContext.SaveChanges();
        }

        public void CreatePerson()
        {
            Person newPerson = new Person();
            Console.WriteLine("Syötä henkilön tiedot: ");
            Console.WriteLine("Nimi: ");
            newPerson.Name = Console.ReadLine();
            Console.WriteLine("Ikä: ");
            newPerson.Age = Console.Read();
            newPerson.Phone = new List<Phone>
            {
                new Phone{Type = "Home", Number = "0502225555"},
            };

            Create(newPerson);
        }



        public void Delete(long id)
        {
            var person = _person_PhoneContext.Person.Find(id);

            if (person == null)
            {
                Console.WriteLine($"Customer with id {id} not found!");
            }

            else
            {
                Console.WriteLine($"Customer: {person.ID}, {person.Name}, {person.Phone}");
                Delete(id);
                Console.WriteLine("Data deleted succesfully.");
            }
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }

        public void Update(long id, Person person)
        {
            var checkPerson = _person_PhoneContext.Person.Find(id);
            if (checkPerson != null)
            {
                _person_PhoneContext.Update(person);
                _person_PhoneContext.SaveChanges();
                Console.WriteLine("Data updated succesfully!");
            }
            else
            {
                Console.WriteLine("Data NOT updated! Id not found.");
            }
        }






        public List<Person> Read()
        {
            var persons = _person_PhoneContext.Person
                .Include(p => p.Phone) // adds phone number to list
                .ToList();
            return persons;
        }

        public Person Read(long id)
        {
            var readPerson = _person_PhoneContext.Person.Include(p => p.Phone)
                .FirstOrDefault(p => p.ID == id);

            if (readPerson == null)
            {
                return null;
            }
            else
            {
                return readPerson;
            }
        }
    }
}