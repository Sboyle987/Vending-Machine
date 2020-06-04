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
            //restock
        }


        public void Restock()
        {
            //set path to get file from
            string path = @"C:\Users\Student\git\c-module-1-capstone-team-8\19_Capstone\vendingmachine.csv"; //TODO 01 CHANGE TO RELATIVE
            //open file
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

        public void FeedMoney(decimal moneyGiven)
        {
            this.Balance += moneyGiven;
        }

        public string PurchaseItem(Item item)
        {
            decimal purchasePrice = item.Price;

            if (purchasePrice <= this.Balance)
            {
                this.Balance -= purchasePrice;
                Inventory[item.SlotLocation].QuantityAvailable--;

                return item.Message;
            }

            return "You don't got no money bro!!!?!?!?";
        }


        public int[] MakeChange()
        {
            //look at the balance of the machine

            decimal currentBalance = Balance; //Create local variable to hold current Balance
            int numberOfQuarters = (int)(currentBalance / 0.25M); //Get the number of quarters
            currentBalance %= 0.25M; //set to remainder and repeat for smaller coins

            int numberOfDimes = (int)(currentBalance / 0.10M);
            currentBalance %= 0.1M;

            int numberOfNickels = (int)(currentBalance / .05M);
            currentBalance %= .05M;

            int[] changeValues = new int[] { numberOfQuarters, numberOfDimes, numberOfNickels}; // generate array to return

            Balance = currentBalance;
            return changeValues;
        }
    }
}
