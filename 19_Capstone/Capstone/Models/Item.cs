using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    abstract class Item
    {
        public string Name { get;  } //readonly
        public string SlotLocation { get;  } //readonly

        public decimal Price { get; } //readonly

        public int QuantityAvailable { get; set; }

        public Item(string name, string slotLocation, decimal price, int quantityAvailable )
        {
            this.Name = name;
            this.SlotLocation = slotLocation;
            this.Price = price;
            this.QuantityAvailable = quantityAvailable;
        }

    }
}
