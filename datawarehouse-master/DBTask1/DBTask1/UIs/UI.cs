using System;
using System.Collections.Generic;
using System.Text;
using DBTask1.Models;
using DBTask1.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DBTask1.UIs
{
    public class UI
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        public string Choice()
        {
            Console.WriteLine("Tietokannat ohjelma");

            Console.WriteLine("[ C ] = Create");
            Console.WriteLine("[ R ] = Read");
            Console.WriteLine("[ U ] = Update");
            Console.WriteLine("[ D ] = Delete");
            Console.WriteLine("[ E ] = Exit");
            string action = Console.ReadLine();
            return action;
        }
        public void SelectAction()
        {
           
            string userInput = null;
            string message = "";

            do
            {
                userInput = Choice();

                switch (userInput.ToUpper())
                {
                    case "C":
                        _personRepository.CreatePerson();
                        break;

                    case "R":
                        var persons = _personRepository.Read();
                        

                        foreach (var p in persons)
                        {
                            Console.WriteLine($"{p.Id}, {p.Name}, {p.Age}");
                            foreach (var tel in p.Phone)
                            {
                                Console.WriteLine($"- {tel.Number}, {tel.Type}");                               
                            }
                            Console.WriteLine();
                        }

                        var searched = _personRepository.Read(1);
                        break;

                    case "U":

                        _personRepository.UpdatePerson();
                        break;

                    case "D":

                        _personRepository.Delete(1);
                        break;

                    case "E":

                        message = "Suljetaan ohjelma";
                        break;

                    default:
                        message = "Väärä näppäin!";
                        break;
                }

                Console.WriteLine(message);
                Console.ReadKey();
                Console.Clear();
                
            }
            while (userInput.ToUpper() != "E");
        }
    }
}
