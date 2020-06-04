using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [DataTestMethod]
        [DataRow("Doritos", "A1", 2.25,"Doritos", "A1",2.25)]
        [DataRow("Stackers", "A2", 1.45, "Stackers", "A2", 1.45)]
        [DataRow("Moonpie", "B1", 1.80, "Moonpie", "B1", 1.80)]
        [DataRow("Little League Chew", "D4", .95, "Little League Chew", "D4", .95)]
        public void OnlyWhenItemIsNotAbstractItemConstructorValueTest(string name, string slot, double price, string expectedName, string expectedSlot, double expectedPrice)
        {
            //Arrange
            decimal dPrice = (decimal)price;

            Item thisItem;


            //Act
            thisItem = new Item(name,slot,dPrice);


            //Assert
            Assert.AreEqual(expectedName, thisItem.Name);
            Assert.AreEqual((decimal)expectedPrice, thisItem.Price);
            Assert.AreEqual(expectedSlot, thisItem.SlotLocation);

        }
    }
}
