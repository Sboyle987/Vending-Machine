using System;
using Capstone.Models;
using Capstone.Models.Items;
using CLI;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            VendingMachine vendMach = new VendingMachine();    

            MainMenu mainMenu = new MainMenu(vendMach);
            mainMenu.Run();
     
            
        }
    }
}
