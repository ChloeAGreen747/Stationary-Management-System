using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment___Chloe_Green
{
    public class StockManager
    {
        private List<Stock> stocks = new List<Stock>();
        private List<TransactionLog> tranLogs = new List<TransactionLog>();
        private List<PersonalUsage> personUsgs = new List<PersonalUsage>();

        public bool checkStock(int itemCode)
        {
            bool inStock = false;
            foreach (Stock stock in stocks)
            {
                if (stock.itemCode == itemCode)
                {
                    inStock = true;
                }
            }

            return inStock;
        }

        public void increaseStock(int itemCode, int quantity, double price)
        {
            foreach (Stock stock in stocks)
            {
                if (stock.itemCode == itemCode)
                {
                    stock.price += price;
                    stock.quantity += quantity;
                }
            }
        }

        public void addStock(Stock s)
        {
            stocks.Add(s);
        }

        public void removeStock(Stock s)
        {
            s.quantity--;
        }

        public void addTransaction(TransactionLog t)
        {
            tranLogs.Add(t);
        }

        public void addPersonalUsage(PersonalUsage p)
        {
            personUsgs.Add(p);
        }
        public List<TransactionLog> getTransactions()
        {
            return tranLogs;
        }

        public List<Stock> getStocks()
        {
            return stocks;
        }

        public List<PersonalUsage> getUsage(string personName)
        {
            List<PersonalUsage> pu = new List<PersonalUsage>();

            foreach (PersonalUsage p in personUsgs)
            {
                if ((p.personName).ToLower() == personName.ToLower())
                {
                    pu.Add(p);
                }
            }
            return pu;
        }

    }
}
