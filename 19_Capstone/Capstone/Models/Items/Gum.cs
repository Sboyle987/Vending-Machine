using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models.Items
{
    public class Gum : Item
    {
        public string Message { get; }

        public Gum(string name, string slotLocation, decimal price)
            : base(name, slotLocation, price)
        {
            this.Message = "Chew Chew, Yum!";
        }

        public string GetMessage()
        {
            return this.Message;
        }
    }
}
