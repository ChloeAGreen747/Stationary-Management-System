using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment___Chloe_Green
{
    public class TransactionUI
    {
        private StockManager stockMgr;

        public TransactionUI(StockManager sm)
        {
            this.stockMgr = sm;
        }

        public void addToStock(int itemCode, string itemName, int quantity, double price, DateTime date)
        {
            if (stockMgr.checkStock(itemCode) == true)
            {
                stockMgr.increaseStock(itemCode, quantity, price);
                List<Stock> stocks = stockMgr.getStocks();

                foreach (Stock stock in stocks)
                {
                    if (stock.itemCode == itemCode)
                    {
                        itemName = stock.name;
                    }
                }
            }
            else
            {
                stockMgr.addStock(new Stock(itemCode, itemName, price, quantity, date));
            }
          
            stockMgr.addTransaction(new TransactionLogAdd("Add", itemCode, itemName, price, date));
        }

        public void takeFromStock(int itemCode, string PersonName, DateTime date)
        {
            List<Stock> stocks = stockMgr.getStocks();
            bool inStock = stockMgr.checkStock(itemCode);
            string n = "";
            int q = 0;

            foreach (Stock stock in stocks)
            {
                if (stock.itemCode == itemCode)
                {
                    q = stock.quantity;
                }
            }

            if (inStock == false)
            {
                Console.WriteLine("Error. This item code doesn't exist");
            }
            else if ( q <= 0)
            {
                Console.WriteLine("Error. No more left in stock");
            }
            else
            {
                foreach (Stock stock in stocks)
                {
                    if (stock.itemCode == itemCode)
                    {
                        stockMgr.removeStock(stock);
                        n = stock.name;
                        stockMgr.addPersonalUsage(new PersonalUsage(PersonName, itemCode, n, date));
                        stockMgr.addTransaction(new TransactionLogRemove("Take", itemCode, n, PersonName, date));
                    }
                }
            }
        }

        public List<Stock> viewInventoryReport()
        {
            List<Stock> stocks = stockMgr.getStocks();
            List<Stock> stockList = new List<Stock>();

            foreach (Stock stock in stocks)
            {
                if (stock.quantity > 0)
                {
                    stockList.Add(stock);
                }
            }

            return stockList;
        }

        public List<Stock> viewFinancialReport()
        {
            return stockMgr.getStocks();
        }
        public List<TransactionLog> viewtransactionLog()
        {
            return stockMgr.getTransactions();
        }
        public List<PersonalUsage> viewPersonalUsage(string PersonName)
        {
           return stockMgr.getUsage(PersonName);
        }

    }
}
