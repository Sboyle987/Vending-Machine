using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models.Items
{
    public class Chip : Item
    {
        public string Message { get; }

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
