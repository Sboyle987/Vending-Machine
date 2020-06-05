using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Models.Items;

namespace Capstone.Models
{
    public class VendingMachine
    {
        public decimal Balance { get; private set; } = 0.00M;

        //public List<Item> Inventory { get; set; } = new List<Item>();
        public Dictionary<string, Item> Inventory { get; set; } = new Dictionary<string, Item>();

        public VendingMachine()
        {
            Restock();
        }


        public void Restock()
        {
            //set path to get file from
            string path = @"..\..\..\..\vendingmachine.csv"; 

            
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    //read line by line
                    string singleItem = sr.ReadLine();

                    //split by the | delimter to array
                    string[] singleItemContents = singleItem.Split("|");

                    //reference by index and store values in temp variable
                    string tempName = singleItemContents[1];
                    string tempSlot = singleItemContents[0];
                    string tempItemType = singleItemContents[3];
                    decimal tempPrice = decimal.Parse(singleItemContents[2]);

                    //create a new object to assign the values
                    if (tempItemType == "Chip")
                    {
                        Chip tempChip = new Chip(tempName, tempSlot, tempPrice);
                        Inventory.Add(tempSlot, tempChip);
                    }
                    if (tempItemType == "Drink")
                    {
                        Drink tempDrink = new Drink(tempName, tempSlot, tempPrice);
                        Inventory.Add(tempSlot, tempDrink);
                    }
                    if (tempItemType == "Gum")
                    {
                        Gum tempGum = new Gum(tempName, tempSlot, tempPrice);
                        Inventory.Add(tempSlot, tempGum);
                    }
                    if (tempItemType == "Candy")
                    {
                        Candy tempCandy = new Candy(tempName, tempSlot, tempPrice);
                        Inventory.Add(tempSlot, tempCandy);
                    }
                }
            }
        }

    


        public string FeedMoney(decimal moneyGiven) 
        {
            decimal[] realDollars = new decimal[] { 1.00M, 2.00M, 5.00M, 10.00M };
            foreach (decimal dollar in realDollars)
            {
                if (moneyGiven == dollar)
                {
                    this.Balance += moneyGiven;
                    this.DoLog("FEED MONEY", moneyGiven);

                    return "Thank you!";
                }
            }
            
            return "Must feed $1, $2, $5, or $10";
        }

        public string PurchaseItem(string slot) 
        {
            decimal purchasePrice = Inventory[slot].Price;

            if (purchasePrice <= this.Balance)
            {
                this.Balance -= purchasePrice;
                Inventory[slot].QuantityAvailable--;
                this.DoLog(Inventory[slot].Name, Inventory[slot].Price);
                return Inventory[slot].Message; //TODO : Why can't we access the GetMessage?
            }
            return "Insufficient Funds";
        }


        public int[] MakeChange()
        {
            //look at the balance of the machine
            decimal originalBalance = this.Balance;

            decimal currentBalance = Balance; //Create local variable to hold current Balance
            int numberOfQuarters = (int)(currentBalance / 0.25M); //Get the number of quarters
            currentBalance %= 0.25M; //set to remainder and repeat for smaller coins

            int numberOfDimes = (int)(currentBalance / 0.10M);
            currentBalance %= 0.1M;

            int numberOfNickels = (int)(currentBalance / .05M);
            currentBalance %= .05M;

            int[] changeValues = new int[] { numberOfQuarters, numberOfDimes, numberOfNickels}; // generate array to return

            Balance = currentBalance;
            this.DoLog("GIVE CHANGE", originalBalance);
            return changeValues;
        }

        public void DoLog(string process, decimal processBalance)
        {
            string path = @"..\..\..\..\Log.txt";

            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    string log = $"{DateTime.Now} {process}: {processBalance.ToString("C")} ${this.Balance}";
                    sw.WriteLine(log);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    string log = $"{DateTime.Now} {process}: {processBalance.ToString("C")} ${this.Balance}";
                    sw.WriteLine(log);
                }
            }
        }
    }
}
