using System;
using System.Collections.Generic;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void purchaseReport(List<(string, int, double)> purchases)
        {
            foreach((string ticker, int shares, double amount) purchase in purchases)
            {
                Console.WriteLine("     You purchased {0, 4} shares of {1,5} at {2:C}", purchase.shares, purchase.ticker, purchase.amount);
            }
            Console.Write('\n');
        }
        static void ownershipReport(List<(string, int, double)> purchases, Dictionary<string, string> stocks, ref Dictionary<string, double> stockValues)
        {
            foreach((string ticker, int shares, double price) purchase in purchases)
            {
                if (stockValues.ContainsKey(stocks[purchase.ticker]))
                {
                    stockValues[stocks[purchase.ticker]] += purchase.shares * purchase.price;
                }
                else
                {
                    stockValues.Add(stocks[purchase.ticker], purchase.shares * purchase.price);
                }
            }
        }

        static void PrintStockValues(Dictionary<string, double> stockValues)
        {
            foreach (var (company, value) in stockValues)
            {
                Console.WriteLine("     Value of {0,-35} {1,10:C}", String.Concat(company, " holdings:"), value);
            }
            Console.Write('\n');
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo key;

            // Stores ticker symbols with associated company name.
            Dictionary <string, string> stocks = new Dictionary <string, string>();

            // Store individual purchases of stocks.
            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            // Stores aggregate purchase information.
            Dictionary <string, double> stockValues = new Dictionary <string, double>();
            
            Console.WriteLine("\n\n     Stock Tracker\n");
            
            // Add stocks
            stocks.Add("RACE", "Ferrari N.V.");
            stocks.Add("F", "Ford Motor Company");
            stocks.Add("GM", "General Motors Company");
            stocks.Add("TM", "Toyota Motor Corp.");
            stocks.Add("MZDAY", "Mazda Motor");
            stocks.Add("NSANY", "Nissan Motor Company Ltd");


            purchases.Add((ticker: "RACE", shares: 30, price: 208.00));
            purchases.Add((ticker: "RACE", shares: 20, price: 218.68));
            purchases.Add((ticker: "F", shares: 150, price: 11.82));
            purchases.Add((ticker: "F", shares: 200, price: 13.71));
            purchases.Add((ticker: "GM", shares: 80, price: 53.75));
            purchases.Add((ticker: "TM", shares: 50, price: 158.68));
            purchases.Add((ticker: "MZDAY", shares: 200, price: 4.61));
            purchases.Add((ticker: "NSANY", shares: 100, price: 11.13));

            purchaseReport(purchases);
            ownershipReport(purchases, stocks, ref stockValues);
            PrintStockValues(stockValues);

            Console.WriteLine("     Press any key to exit");
            key = Console.ReadKey();

            
        }
    }
}
