using System;
using DBTask1.Models;
using DBTask1.Repositories;
using DBTask1.UIs;
using System.Linq;
using System.Collections.Generic;

namespace DBTask1
{
    class Program
    {
        

        static void Main(string[] args)
        {
 
                UI ui = new UI();
                ui.Choice();
                ui.SelectAction();

        }
    }
}
