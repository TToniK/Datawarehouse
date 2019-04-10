using System;
using System.Collections.Generic;
using System.Text;
using Person_Phone.Models;

namespace Person_Phone.Repositories
{
    interface IPerson_Phone
    {
        //CRUD
        void Create(Person person);
        List<Person> Read();
        void Update(long id, Person person);
        void Delete(long id);


    }
}
