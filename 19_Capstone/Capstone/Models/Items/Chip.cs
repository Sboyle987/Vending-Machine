using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models.Items
{
    public class Chip : Item
    {
        public override string Message { get; set; }

        public Chip(string name, string slotLocation, decimal price) 
            : base(name, slotLocation,  price)
        {
            this.Message = "Crunch Crunch, Yum!";
        }

        public string GetMessage()
        {
            return this.Message;
        }
    }
}
