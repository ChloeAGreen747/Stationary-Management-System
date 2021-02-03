using System;
using System.Collections.Generic;

namespace Assignment___Chloe_Green
{
    class Program
    {
        private static TransactionUI trnUI;
        private static StockManager stockMgr;
        static void Main(string[] args)
        {
            stockMgr = new StockManager();
            trnUI = new TransactionUI(stockMgr);

            int option = DisplayMenu();
            
            while (option != 7)
            {
                switch (option)
                {
                    case 1:
                        AddToStock();
                        break;
                    case 2:
                        TakeFromStock();
                        break;
                    case 3:
                        InventoryReport();
                        break;
                    case 4:
                        FinancialReport();
                        break;
                    case 5:
                        TransactionLog();
                        break;
                    case 6:
                        PersonalUsage();
                        break;
                }
                option = DisplayMenu();
            }
        }

        private static int DisplayMenu()
        {
            Console.WriteLine("\n1. Add to Stock");
            Console.WriteLine("2. Take from Stock");
            Console.WriteLine("3. Display Inventory Report");
            Console.WriteLine("4. Display Financial Report");
            Console.WriteLine("5. Display Transaction Log");
            Console.WriteLine("6. Display Personal Usage Report");
            Console.WriteLine("7. Exit");
            Console.WriteLine("\n");

            bool option_chosen = false;
            int answer = 0;
            while (option_chosen != true)
            {
                answer = ValidateInt("Option");
                if (answer > 0 && answer < 8)
                {
                    option_chosen = true;
                }
                else
                {
                    Console.WriteLine("ERROR Option Invalid");
                }
            }
            return answer;
        }

        private static int ValidateInt(string type)
        {
            bool valid = false;
            int value = 0;
            Console.Write("Enter " + type + " > ");
            string answer = Console.ReadLine();

            while (valid != true)
            {
                if (answer.Length > 0)
                {
                    try
                    {
                        value = Convert.ToInt32(answer);
                        if (value >= 1)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR " + type + " invalid");
                            Console.Write("Enter " + type + " > ");
                            value = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("ERROR " + type + " invalid");
                        Console.Write("Enter " + type + " > ");
                        answer = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR " + type + " invalid");
                        Console.Write("Enter " + type + " > ");
                        answer = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("ERROR " + type + " invalid");
                    Console.Write("Enter " + type + " > ");
                    answer = Console.ReadLine();
                }
            }

            return value;
        }

        private static double ValidateDouble(string type)
        {
            bool valid = false;
            double value = 0;
            Console.Write("Enter " + type + " > ");
            string answer = Console.ReadLine();

            while (valid != true)
            {
                if (answer.Length > 0)
                {
                    try
                    {
                        value = double.Parse(answer);
                        if (value > 0)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR " + type + " invalid");
                            Console.Write("Enter " + type + " > ");
                            value = double.Parse(Console.ReadLine());
                        }
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("ERROR " + type + " invalid");
                        Console.Write("Enter " + type + " > ");
                        answer = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR " + type + " invalid");
                        Console.Write("Enter " + type + " > ");
                        answer = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("ERROR " + type + " invalid");
                    Console.Write("Enter " + type + " > ");
                    answer = Console.ReadLine();
                }
            }

            return value;
        }

        private static string ValidateString(string type)
        {
            bool valid = false;
            Console.Write("Enter " + type + " > ");
            string value = Console.ReadLine();

            while (valid != true)
            {
                if ((value.Length <= 30) && (value.Length >= 1))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("ERROR " + type + " invalid");
                    Console.Write("Enter " + type + " > ");
                    value = Console.ReadLine();
                }
            }
            return value;
        }
        private static void AddToStock()
        {
            int itemcode = ValidateInt("Item Code");
            string name = "";
            int quantity = 0;
            double price = 0;

            if (stockMgr.checkStock(itemcode) == true)
            {
                Console.WriteLine("This item code already exists. Please enter the quantity and price to be added:");
                quantity = ValidateInt("Quantity");
                price = ValidateDouble("Price");
            }
            else
            {
                name = ValidateString("Name");
                quantity = ValidateInt("Quantity");
                price = ValidateDouble("Price");
            }

            trnUI.addToStock(itemcode, name, quantity, price, DateTime.Now);
        }

        private static void TakeFromStock()
        {
            int ic = ValidateInt("Item Code");
            string pn = ValidateString("Name of Person Taking Item");

            trnUI.takeFromStock(ic, pn, DateTime.Now);
        }

        private static void InventoryReport()
        {
            List<Stock> stocklist = trnUI.viewInventoryReport();

            Console.WriteLine("\nInventory Report");
            Console.WriteLine("\t{0, -12} {1, -18} {2, -12}","Item Code", "Item Name", "Quantity");

            foreach (Stock stock in stocklist)
            {
                Console.WriteLine("\t{0, -12} {1, -18} {2, -12}",
                    stock.itemCode.ToString(),
                    stock.name,
                    stock.quantity);
            }
        }

        private static void FinancialReport()
        {
            List<Stock> stocklist = trnUI.viewFinancialReport();

            Console.WriteLine("\nFinancial Report");
            Console.WriteLine("\t{0, -12} {1, -20} {2, -12}", "Item Code", "Item Name", "Total Cost");
            double total_expenditure = 0;

            foreach (Stock stock in stocklist)
            {
                Console.WriteLine("\t{0, -12} {1, -20} {2, -12}", stock.itemCode, stock.name, "£" + string.Format("{0:0.00}", stock.price));
                total_expenditure += stock.price;
            }
            Console.WriteLine("\n\tTotal spent on items: £" + string.Format("{0:0.00}", total_expenditure));
        }

        private static void TransactionLog()
        {
            List<TransactionLog> transactions = trnUI.viewtransactionLog();

            Console.WriteLine("\nTransaction Log");
            Console.WriteLine("\t{0, -12} {1, -12} {2, -20} {3, -20} {4, -12} {5, -12}", "Type", "Item Code", "Item Name", "Person Name", "Price Paid", "Date");

            foreach (TransactionLog transaction in transactions)
            {
                if (transaction.type == "Add")
                {
                    Console.WriteLine("\t{0, -12} {1, -12} {2, -20} {3, -20} {4, -12} {5, -12}",
                        transaction.type,
                        transaction.itemCode,
                        transaction.name,
                        "--",
                        "£" + string.Format("{0:0.00}", double.Parse(transaction.ToString())),
                        transaction.date);
                }
                else
                {
                    Console.WriteLine("\t{0, -12} {1, -12} {2, -20} {3, -20} {4, -12} {5, -12}",
                        transaction.type,
                        transaction.itemCode,
                        transaction.name,
                        transaction.ToString(),
                        "--",
                        transaction.date);
                }
            }
        }

        private static void PersonalUsage()
        {
            string n = ValidateString("your name");
            int count = 0;

            List<PersonalUsage> personalusage = trnUI.viewPersonalUsage(n);

            foreach (PersonalUsage p in personalusage)
            {
                count += 1;
            }

            if (count == 0)
            {
                Console.WriteLine("ERROR Person doesn't exist");
            }
            else
            {
                Console.WriteLine("\nPersonal Usage");
                Console.WriteLine("\t{0, -12} {1, -20} {2, -12}", "Item Code", "Person Name", "Date Taken");

                foreach (PersonalUsage p in personalusage)
                {
                    Console.WriteLine("\t{0, -12} {1, -20} {2, -12}",
                    p.itemCode,
                    p.personName,
                    p.date);
                }
            }
        }
    }
}