using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment___Chloe_Green
{
    public class TransactionLogAdd : TransactionLog
    {
        public double price { get; }

        public TransactionLogAdd(string type, int itemCode, string name, double price, DateTime d) : base(type, itemCode, name ,d)
        {
            this.price = price;
        }

        public override string ToString()
        {
            return Convert.ToString(price);
        }

    }
}
