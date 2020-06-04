using System;
using Capstone.Models;
using Capstone.Models.Items;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            VendingMachine vm = new VendingMachine();
            vm.Restock();
            vm.FeedMoney(10);
            vm.PurchaseItem(new Chip("Potato Crisps", "A1", 3.05M));
            int[] tempArray = vm.MakeChange();

            foreach (var value in tempArray)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
        }
    }
}
