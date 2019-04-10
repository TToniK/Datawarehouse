using System;
using System.Collections.Generic;
using System.Text;
using DBTask1.Models;

namespace DBTask1.Repositories
{
   
    public interface IPersonRepository
    {
        
        void Create(Person person);

        List<Person> Read();
        Person Read(long id);

        void Update(long id, Person person);

        void Delete(long id);
    }
}
