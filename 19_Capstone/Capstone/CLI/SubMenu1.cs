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

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SubMenu1(/** Variables may be passed in... ***/) :
            base("Sub-Menu 1")
        {
            // Store any values passed in....
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
                        decimal valueToFeed = GetDecimal("Please insert a bill (1.00, 2.00, 5.00, or 10.00)");
                        string message = vm.FeedMoney(valueToFeed);
                        
                        if (message == "Thank you!")
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{message}. You inserted ${valueToFeed}");
                        }
                    }

                    Pause("");
                    return true;
                case "2": // Do whatever option 2 is
                    Console.Clear();
                    Console.WriteLine($"Please make your selection using the product's slot.");
                    foreach (var entry in vm.Inventory)
                    {
                        Console.WriteLine($"{entry.Value.SlotLocation}: {entry.Value.Name} costs ${entry.Value.Price} - Qty {entry.Value.QuantityAvailable}");
                    }

                    while (true)
                    {

                        string userSelectedSlot = GetString("Slot: ");
                        if (vm.Inventory.ContainsKey(userSelectedSlot) && vm.Inventory[userSelectedSlot].QuantityAvailable != 0)
                        {
                            string consumptionOutput = vm.PurchaseItem(userSelectedSlot);
                            Console.WriteLine(consumptionOutput);
                            break;
                        }
                        else if (vm.Inventory[userSelectedSlot].QuantityAvailable == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("SOLD OUT.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input");
                        }

                    }

                    Pause("");
                    return true;
                case "3":
                    Console.Clear();
                    int[] changeToGive = vm.MakeChange();
                    Console.WriteLine($"Quarters: {changeToGive[0]}, Dimes: {changeToGive[1]} Nickels: {changeToGive[2]}");
                    Console.WriteLine(vm.Balance);

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
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine($"Current Balance: {vm.Balance}");
            ResetColor();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.Magenta);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Sub-Menu 1"));
            ResetColor();
        }

    }
} 
