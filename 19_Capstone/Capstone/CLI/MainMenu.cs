using Capstone.Models;
using System;
using System.Collections.Generic;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        // You may want to store some private variables here.  YOu may want those passed in 
        // in the constructor of this menu
        public VendingMachine vm;
        /// <summary>
        /// Constructor adds items to the top-level menu. You will likely have parameters  passed in
        /// here...
        /// </summary>
        public MainMenu(VendingMachine vendMach) : base("Main Menu")
        {
            vm = vendMach;
            // Set any private variables here.
        }

        protected override void SetMenuOptions()
        {
            // A Sample menu.  Build the dictionary here
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("3", "Exit");
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
                case "1":
                    Console.Clear();

                    SetColor(ConsoleColor.DarkCyan);
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Vendo-Matic 800 - Tech Elevator Cleveland Campus");
                    Console.WriteLine("------------------------------------------------");
                    ResetColor();
                    foreach (KeyValuePair<string, Capstone.Models.Item> entry in vm.Inventory)
                    {
                        Console.Write($"{entry.Value.Name}");
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
                    Pause("");
                    return true;    // Keep running the main menu

                case "2": // Do whatever option 2 is

                    SubMenu1 purchaseMenu = new SubMenu1(vm);
                    purchaseMenu.Run();

                    return true;    // Keep running the main menu
                case "3": 


                    return false;    // Keep running the main menu
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }


        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkCyan);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Vendo-Matic 800"));
            ResetColor();
        }
    }
}
