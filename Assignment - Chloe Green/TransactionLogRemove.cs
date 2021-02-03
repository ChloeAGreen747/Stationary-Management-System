using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment___Chloe_Green
{
    public class TransactionLogRemove : TransactionLog
    {
        public string personName { get; }

        public TransactionLogRemove(string type, int itemCode, string name, string personName, DateTime d) : base(type, itemCode, name, d)
        {
            this.personName = personName;
        }

        public override string ToString()
        {
            return personName;
        }
    }

}
