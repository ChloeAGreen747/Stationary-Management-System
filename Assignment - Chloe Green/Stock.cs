using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment___Chloe_Green
{
    public class Stock
    {
        public int itemCode { get; }
        public string name { get; }
        public double price { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; }

        public Stock(int itemCode, string itemName, double price, int quantity, DateTime date)
        {
            this.itemCode = itemCode;
            this.name = itemName;
            this.price = price;
            this.quantity = quantity;
            this.date = date;
        }
    }
}
