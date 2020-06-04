using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Models.Items;

namespace Capstone.Models
{
    public class VendingMachine
    {
        public decimal Balance { get; set; } = 0.00M;

        public List<Item> Inventory { get; set; } = new List<Item>();

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
                        Inventory.Add(tempChip);
                    }
                    if (tempItemType == "Drink")
                    {
                        Inventory.Add(new Drink(tempName, tempSlot, tempPrice));
                    }
                    if (tempItemType == "Gum")
                    {
                        Inventory.Add(new Gum(tempName, tempSlot, tempPrice));
                    }
                    if (tempItemType == "Candy")
                    {
                        Inventory.Add(new Candy(tempName, tempSlot, tempPrice));
                    }


                }
            }
            
            
            


        }
    }
}
