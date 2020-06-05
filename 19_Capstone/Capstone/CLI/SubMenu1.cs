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
            this.quitKey = "3";
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
                    decimal valueToFeed = GetDecimal("Please insert a bill (1.00, 2.00, 5.00, or 10.00)");
                    vm.FeedMoney(valueToFeed);
                    Console.WriteLine($"You have inserted ${valueToFeed}.");
                    Pause("");
                    return true;
                case "2": // Do whatever option 2 is
                    Console.Clear();
                    Console.WriteLine($"Please make your selection using the product's slot.");
                    foreach (var entry in vm.Inventory)
                    {
                        Console.WriteLine($"{entry.Value.SlotLocation}: {entry.Value.Name} costs ${entry.Value.Price} - Qty {entry.Value.QuantityAvailable}");
                    }
                    string userSelectedSlot = GetString("Slot: ");
                    string consumptionOutput = vm.PurchaseItem(userSelectedSlot);
                    Console.WriteLine(consumptionOutput);


                    Pause("");
                    return true;
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
            Console.WriteLine("Display some data here, AFTER the sub-menu is shown....");
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
