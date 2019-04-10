using System;
using Person_Phone.Models;
using Person_Phone.Repositories;
using Person_Phone.UI;
using System.Linq;
using System.Collections.Generic;

namespace DBTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();

            Console.WriteLine("DATABASE MANAGER\nChoose an action and press ENTER:");

            Console.WriteLine("[ C ] = Create");
            Console.WriteLine("[ R ] = Read");
            Console.WriteLine("[ U ] = Update");
            Console.WriteLine("[ D ] = Delete");
            Console.WriteLine("[ E ] = Exit the program.");

            ui.SelectAction();

            Console.WriteLine("Press enter to continue..");
            Console.ReadLine();
        }
    }
}