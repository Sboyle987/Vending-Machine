using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
using Capstone.Models.Items;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [DataTestMethod]
        [DataRow("Smarties", "A1", 2.25,"Smarties", "A1",2.25, "Munch Munch, Yum!")]
        public void CandyConstructorValueTest(string name, string slot, double price, 
            string expectedName, string expectedSlot, double expectedPrice, string expectedMessage)
        {
            //Arrange
            decimal dPrice = (decimal)price;

            Candy thisItem;


            //Act
            thisItem = new Candy(name,slot,dPrice);


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
    }
}
