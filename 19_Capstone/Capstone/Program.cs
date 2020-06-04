using System;
using Capstone.Models;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            VendingMachine vm = new VendingMachine();
            vm.Restock();
            Console.WriteLine();
        }
    }
}
