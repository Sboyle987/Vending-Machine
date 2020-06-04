using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public abstract class Item //Made this NOT abstract for testing. Convert to abstract later.
    {
        public string Name { get;  } //readonly
        public string SlotLocation { get;  } //readonly

        public decimal Price { get; } //readonly

        public int QuantityAvailable { get; set; } = 5;

        public Item(string name, string slotLocation, decimal price)
        {
            this.Name = name;
            this.SlotLocation = slotLocation;
            this.Price = price;
        }

    }
}
