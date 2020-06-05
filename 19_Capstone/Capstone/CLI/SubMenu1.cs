using Capstone.Models;
using System;
using System.Collections.Generic;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class SubMenu1 : CLIMenu
    {
        // Store any private variables here....
        VendingMachine vm = new VendingMachine();
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SubMenu1(VendingMachine subVM ) :
            base("Sub-Menu 1")
        {
            vm = subVM;
        }

        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");
            this.quitKey = "q";
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1": // Do whatever option 1 is
                    Console.Clear();
                    
                    
                    while(true)
                    {   
                        decimal valueToFeed = GetDecimal("Please insert a bill ($1.00, $2.00, $5.00, or $10.00)");
                        string message = vm.FeedMoney(valueToFeed);
                        if (message == "Thank you!")
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{message}. You inserted ${valueToFeed}");
                            break;
                        }
                    }

                    Pause("");
                    return true;
                case "2": // Do whatever option 2 is
                    Console.Clear();

                    SetColor(ConsoleColor.DarkCyan);
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("Please make your selection using the product's slot.");
                    Console.WriteLine("----------------------------------------------------");
                    ResetColor();
                    foreach (var entry in vm.Inventory)
                    {
                        Console.Write($"{entry.Value.SlotLocation}: ");
                        Console.Write($"{entry.Value.Name} | ");
                        SetColor(ConsoleColor.Green);
                        Console.Write($"${entry.Value.Price} ");
                        ResetColor();
                        if (entry.Value.QuantityAvailable == 0)
                        {
                            SetColor(ConsoleColor.Red);
                            Console.Write($" SOLD OUT\n");
                            ResetColor();
                        }
                        else
                        {
                            Console.Write($"| Qty {entry.Value.QuantityAvailable}\n");
                        }
                        
                       
                    }

                    while (true)
                    {

                        string userSelectedSlot = GetString("Slot: ").ToUpper();
                        if (vm.Inventory.ContainsKey(userSelectedSlot) && vm.Inventory[userSelectedSlot].QuantityAvailable != 0)
                        {
                            string consumptionOutput = vm.PurchaseItem(userSelectedSlot);
                            SetColor(ConsoleColor.White);
                            Console.WriteLine(consumptionOutput);
                            ResetColor();
                            break;
                        }
                        else if (vm.Inventory.ContainsKey(userSelectedSlot) && vm.Inventory[userSelectedSlot].QuantityAvailable == 0)
                        {
                            Console.Clear();
                            SetColor(ConsoleColor.Red);
                            Console.WriteLine("SOLD OUT");
                            ResetColor();
                            break;
                        }
                        else if (!vm.Inventory.ContainsKey(userSelectedSlot))
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input");
                            break;
                        }

                    }

                    Pause("");
                    return true;
                case "3":
                    decimal balanceBeforeMachineIsEmptied = vm.Balance;
                    Console.Clear();
                    int[] changeToGive = vm.MakeChange();
                    SetColor(ConsoleColor.White);
                    Console.WriteLine($"Here's your change: ${balanceBeforeMachineIsEmptied}");
                    ResetColor();
                    Console.WriteLine($"Quarters: {changeToGive[0]}, Dimes: {changeToGive[1]} Nickels: {changeToGive[2]}");
                    Console.Write("Have a nice day!");
                    

                    Pause("");
                    return false;
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }

        protected override void AfterDisplayMenu()
        {
            base.AfterDisplayMenu();
            SetColor(ConsoleColor.DarkCyan);
            Console.Write($"Current Balance: ");
            ResetColor();
            SetColor(ConsoleColor.White);
            Console.Write($"${vm.Balance}\n");
            ResetColor();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkYellow);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Snack Time"));
            ResetColor();
        }

    }
} 
