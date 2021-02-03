using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment___Chloe_Green
{
    public abstract class TransactionLog
    {
        public string type { get; }
        public int itemCode { get; }
        public string name { get; }
        public DateTime date { get; }

        public TransactionLog(string type, int itemCode, string name, DateTime d)
        {
            this.type = type;
            this.itemCode = itemCode;
            this.name = name;
            this.date = d;
        }

        public abstract override string ToString();

    }
}
