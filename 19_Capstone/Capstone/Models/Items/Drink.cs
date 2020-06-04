using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models.Items
{
    public class Drink : Item
    {
        public override string Message { get; set; }

        public Drink(string name, string slotLocation, decimal price)
            : base(name, slotLocation, price)
        {
            this.Message = "Glug Glug, Yum!";
        }

        public string GetMessage()
        {
            return this.Message;
        }
    }
}
