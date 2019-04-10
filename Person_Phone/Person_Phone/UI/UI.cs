using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Person_Phone.Repositories;

namespace Person_Phone.UI
{
    class UI
    {
        private static readonly Person_PhoneRepositories _person_PhoneRepositories = new Person_PhoneRepositories();

        public void SelectAction()
        {
            // Creating the user interface
            string userInput = null;
            string message = "";

            do
            {
                userInput = Console.ReadLine();

                switch (userInput.ToUpper())
                {
                    case "C":
                        _person_PhoneRepositories.CreatePerson();
                        break;

                    case "R":
                        var persons = _person_PhoneRepositories.Read();
                        //List<Phone> phones = new List<Phone>();

                        foreach (var p in persons)
                        {
                            Console.WriteLine($"{p.ID}, {p.Name}, {p.Age}");
                            foreach (var tel in p.Phone)
                            {
                                Console.WriteLine($"- {tel.Number}, {tel.Type}");
                            }
                            Console.WriteLine();
                        }

                        var searched = _person_PhoneRepositories.Read();
                        break;

                    case "U":

                        _person_PhoneRepositories.Update();
                        break;

                    case "D":

                        _person_PhoneRepositories.Delete(1);
                        break;

                    case "E":

                        message = "\nExiting program.";
                        break;

                    default:
                        message = "Invalid option."; // all other keys go through this
                        break;
                }

                Console.WriteLine(message);
                Console.ReadKey();
                Console.Clear();
            }
            while (userInput.ToUpper() != "E"); // for exiting program
        }
    }
}
