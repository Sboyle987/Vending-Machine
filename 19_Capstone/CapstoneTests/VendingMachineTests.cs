using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
using Capstone.Models.Items;
using System.IO;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [DataTestMethod]
        [DataRow("Smarties", "A1", 2.25, "Smarties", "A1", 2.25, "Munch Munch, Yum!")]
        public void CandyConstructorValueTest(string name, string slot, double price,
            string expectedName, string expectedSlot, double expectedPrice, string expectedMessage)
        {
            //Arrange
            decimal dPrice = (decimal)price;

            Candy thisItem;


            //Act
            thisItem = new Candy(name, slot, dPrice);


            //Assert
            Assert.AreEqual(expectedName, thisItem.Name);
            Assert.AreEqual((decimal)expectedPrice, thisItem.Price);
            Assert.AreEqual(expectedSlot, thisItem.SlotLocation);
            Assert.AreEqual(expectedMessage, thisItem.Message);

        }

        [DataTestMethod]
        [DataRow("Doritos", "A1", 2.25, "Doritos", "A1", 2.25, "Crunch Crunch, Yum!")]
        public void ChipConstructorValueTest(string name, string slot, double price,
            string expectedName, string expectedSlot, double expectedPrice, string expectedMessage)
        {
            //Arrange
            decimal dPrice = (decimal)price;

            Chip thisItem;


            //Act
            thisItem = new Chip(name, slot, dPrice);


            //Assert
            Assert.AreEqual(expectedName, thisItem.Name);
            Assert.AreEqual((decimal)expectedPrice, thisItem.Price);
            Assert.AreEqual(expectedSlot, thisItem.SlotLocation);
            Assert.AreEqual(expectedMessage, thisItem.Message);

        }

        [DataTestMethod]
        [DataRow("Big League Chew", "A1", 2.25, "Big League Chew", "A1", 2.25, "Chew Chew, Yum!")]
        public void GumConstructorValueTest(string name, string slot, double price,
            string expectedName, string expectedSlot, double expectedPrice, string expectedMessage)
        {
            //Arrange
            decimal dPrice = (decimal)price;

            Gum thisItem;


            //Act
            thisItem = new Gum(name, slot, dPrice);


            //Assert
            Assert.AreEqual(expectedName, thisItem.Name);
            Assert.AreEqual((decimal)expectedPrice, thisItem.Price);
            Assert.AreEqual(expectedSlot, thisItem.SlotLocation);
            Assert.AreEqual(expectedMessage, thisItem.Message);

        }

        [DataTestMethod]
        [DataRow("Coke", "A1", 2.25, "Coke", "A1", 2.25, "Glug Glug, Yum!")]
        public void DrinkConstructorValueTest(string name, string slot, double price,
            string expectedName, string expectedSlot, double expectedPrice, string expectedMessage)
        {
            //Arrange
            decimal dPrice = (decimal)price;

            Drink thisItem;


            //Act
            thisItem = new Drink(name, slot, dPrice);


            //Assert
            Assert.AreEqual(expectedName, thisItem.Name);
            Assert.AreEqual((decimal)expectedPrice, thisItem.Price);
            Assert.AreEqual(expectedSlot, thisItem.SlotLocation);
            Assert.AreEqual(expectedMessage, thisItem.Message);

        }

        [DataTestMethod]
        [DataRow("A1", "Potato Crisps", 3.05, "Chip")]
        public void VendingMachineRestockChipCheck(string expectedSlot, string expectedName, double expectedPrice, string expectedType)
        {
            //Arrange
            VendingMachine vm = new VendingMachine();

            //Act
            
            Chip chipObject = new Chip(expectedName, expectedSlot, (decimal)expectedPrice);

            //Assert
            Assert.AreEqual(vm.Inventory[expectedSlot].Name, expectedName);
            Assert.AreEqual((double)(vm.Inventory[expectedSlot].Price), expectedPrice);
            Assert.AreEqual(vm.Inventory[expectedSlot].SlotLocation, expectedSlot);
        }


        [DataTestMethod]
        [DataRow("B1", "Moonpie", 1.80, "Candy")]
        public void VendingMachineRestockCandyCheck(string expectedSlot, string expectedName, double expectedPrice, string expectedType)
        {
            //Arrange
            VendingMachine vm = new VendingMachine();

            //Act
            
            Candy candyObject = new Candy(expectedName, expectedSlot, (decimal)expectedPrice);

            //Assert
            Assert.AreEqual(vm.Inventory[expectedSlot].Name, expectedName);
            Assert.AreEqual((double)(vm.Inventory[expectedSlot].Price), expectedPrice);
            Assert.AreEqual(vm.Inventory[expectedSlot].SlotLocation, expectedSlot);
        }


        [DataTestMethod]
        [DataRow("C1", "Cola", 1.25, "Drink")]
        public void VendingMachineRestockDrinkCheck(string expectedSlot, string expectedName, double expectedPrice, string expectedType)
        {
            //Arrange
            VendingMachine vm = new VendingMachine();

            //Act
           
            Drink drinkObject = new Drink(expectedName, expectedSlot, (decimal)expectedPrice);

            //Assert
            Assert.AreEqual(vm.Inventory[expectedSlot].Name, expectedName);
            Assert.AreEqual((double)(vm.Inventory[expectedSlot].Price), expectedPrice);
            Assert.AreEqual(vm.Inventory[expectedSlot].SlotLocation, expectedSlot);
        }


        [DataTestMethod]
        [DataRow("D2", "Little League Chew", .95, "Gum")]
        public void VendingMachineRestockGumCheck(string expectedSlot, string expectedName, double expectedPrice, string expectedType)
        {
            //Arrange
            VendingMachine vm = new VendingMachine();

            //Act
            
            Gum gumObject = new Gum(expectedName, expectedSlot, (decimal)expectedPrice);

            //Assert
            Assert.AreEqual(vm.Inventory[expectedSlot].Name, expectedName);
            Assert.AreEqual((double)(vm.Inventory[expectedSlot].Price), expectedPrice);
            Assert.AreEqual(vm.Inventory[expectedSlot].SlotLocation, expectedSlot);
        }


        [DataTestMethod]
        [DataRow(1, 1.00)]
        [DataRow(2, 2.00)]
        [DataRow(5, 5.00)]
        [DataRow(10, 10.00)]
        public void MakeSureThatMoneyIsAddedToBalance(double money, double expectedBalance)
        {
            // Arrange
            VendingMachine vendingMachine = new VendingMachine();

            // Act
            vendingMachine.FeedMoney((decimal)money);

            // Assert
            Assert.AreEqual((decimal)expectedBalance, vendingMachine.Balance);
        }
        [DataTestMethod]
        [DataRow("D2", "Little League Chew", .95, 9.05)]
        public void PurchaseTestMethod(string testSlotLocation, string testName, double testPrice, double expectedBalance)  //Checks that the price is subtracted from balance
        {
            // Arrange 
            VendingMachine vendingMachine = new VendingMachine();
            
            
            // Act
            vendingMachine.FeedMoney(10.00M);
            vendingMachine.PurchaseItem("D2");
            // Assert
            Assert.AreEqual((decimal)expectedBalance, vendingMachine.Balance);
        }
        [TestMethod]
        public void PurchaseTestMethodDecrementsQuantityAvailable()
        {
            // Arrange
            VendingMachine vendingMachine = new VendingMachine();
            
            vendingMachine.FeedMoney(10.00M);
            // Act
            //("B1", "Moonpie", 1.80, "Candy")
            Candy candy = new Candy("Moonpie", "B1", (decimal)1.80);
            vendingMachine.PurchaseItem("B1");
            // Assert
            Assert.IsTrue(vendingMachine.Inventory["B1"].QuantityAvailable == 4);


        }


        [DataTestMethod]
        [DataRow("Moonpie", "B1", 1.80, "Munch Munch, Yum!")]
        public void PurchaseTestMethodReturnsProperYumYumForCandy(string name, string slot, double price, string expectedString)
        {
            // Arrange
            VendingMachine vendingMachine = new VendingMachine();
            
            vendingMachine.FeedMoney(10.00M);
            // Act
            Candy candy = new Candy(name, slot, (decimal)price);
            vendingMachine.PurchaseItem("B1");
            // Assert
            Assert.IsTrue(vendingMachine.Inventory[slot].Message == expectedString);
        }

        [DataTestMethod] //A2|Stackers|1.45|Chip
        [DataRow("Stackers", "A2", 1.45, "Crunch Crunch, Yum!")]
        public void PurchaseTestMethodReturnsProperYumYumForChips(string name, string slot, double price, string expectedString)
        {
            // Arrange
            VendingMachine vendingMachine = new VendingMachine();
            
            vendingMachine.FeedMoney(10.00M);
            // Act
            Candy candy = new Candy(name, slot, (decimal)price);
            vendingMachine.PurchaseItem("A2");
            // Assert
            Assert.IsTrue(vendingMachine.Inventory[slot].Message == expectedString);
        }

        [DataTestMethod] //C2|Dr. Salt|1.50|Drink
        [DataRow("Dr. Salt", "C2", 1.50, "Glug Glug, Yum!")]
        public void PurchaseTestMethodReturnsProperYumYumForDrink(string name, string slot, double price, string expectedString)
        {
            // Arrange
            VendingMachine vendingMachine = new VendingMachine();
            
            vendingMachine.FeedMoney(10.00M);
            // Act
            Drink drink = new Drink(name, slot, (decimal)price);
            vendingMachine.PurchaseItem("C2");
            // Assert
            Assert.IsTrue(vendingMachine.Inventory[slot].Message == expectedString);
        }

        [DataTestMethod] //D3|Chiclets|0.75|Gum
        [DataRow("Chiclets", "D3", .75, "Chew Chew, Yum!")]
        public void PurchaseTestMethodReturnsProperYumYumForGum(string name, string slot, double price, string expectedString)
        {
            // Arrange
            VendingMachine vendingMachine = new VendingMachine();
            
            vendingMachine.FeedMoney(10.00M);
            // Act
            Candy candy = new Candy(name, slot, (decimal)price);
            vendingMachine.PurchaseItem("D3");
            // Assert
            Assert.IsTrue(vendingMachine.Inventory[slot].Message == expectedString);
        }



        [DataTestMethod]
        [DataRow("Grain Waves", "A3", 2.75, new int[] { 29, 0, 0})]
        [DataRow("Moonpie", "B1", 1.80, new int[] { 32, 2, 0 })]
        [DataRow("Cloud Popcorn", "A4", 3.65, new int[] { 25, 1, 0 })]
        [DataRow("Cowtales", "B2", 1.50, new int[] { 34, 0, 0 })]
        [DataRow("Little League Chew", "D2", .95, new int[] { 36, 0, 1 })]

        public void TestGetChangeValues(string name, string slot, double price, int[] expectedChange)
        {
            // Arrange
            VendingMachine vendingMachine = new VendingMachine();
            
            vendingMachine.FeedMoney(10.00M);
            // Act
            Candy candy = new Candy(name, slot, (decimal)price);
            vendingMachine.PurchaseItem(slot);
            // Assert
            CollectionAssert.AreEqual(expectedChange, vendingMachine.MakeChange());
        }

        //[TestMethod]
        //public void TestDoLog()
        //{
        //    //Arrange
        //    VendingMachine vendingMachine = new VendingMachine();
        //    vendingMachine.Restock();

        //    //Act
        //    vendingMachine.FeedMoney(10.00M);
        //    vendingMachine.MakeChange();
        //    vendingMachine.PurchaseItem(vendingMachine.Inventory["A2"]);
        //    //Assert
        //    using (StreamReader stream = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-8\19_Capstone\Log.txt")) //TODO 05 Change to relative path
        //    {
        //        while (!stream.EndOfStream)
        //        {
        //            string[] line = new string[] { stream.ReadLine() };
        //            Assert.IsTrue(line[0].Contains("FEED MONEY: $10.00 $10.00"));
        //        }

                
            // }
            
       // }
    }
}
