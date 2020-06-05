﻿using System;
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
            
            
            
            
            //Console.WriteLine("Hello World!");

            //VendingMachine vm = new VendingMachine();
            //vm.Restock();
            //vm.FeedMoney(10);
     
            //int[] tempArray = vm.MakeChange();

            //foreach (var value in tempArray)
            //{
            //    Console.WriteLine(value);
            //}
            //Console.WriteLine();
        }
    }
}
