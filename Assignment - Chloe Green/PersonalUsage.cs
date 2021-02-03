using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment___Chloe_Green
{
    public class PersonalUsage
    {
        public string personName { get; }
        public int itemCode { get; }
        public string name { get; }
        public DateTime date { get; }

        public PersonalUsage(string personName, int itemCode, string itemName, DateTime date)
        {
            this.personName = personName;
            this.itemCode = itemCode;
            this.name = itemName;
            this.date = date;
        }
    }
}
