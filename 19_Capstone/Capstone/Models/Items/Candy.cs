using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models.Items
{
    public class Candy : Item
    {
        public string Message { get; }

        public Candy(string name, string slotLocation, decimal price)
            : base(name, slotLocation, price)
        {
            this.Message = "Munch Munch, Yum!";
        }

        public string GetMessage()
        {
            return this.Message;
        }
    }
}
