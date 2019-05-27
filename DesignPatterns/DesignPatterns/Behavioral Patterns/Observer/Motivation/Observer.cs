/*
 * Observer Pattern
   This module explores the observer pattern which allows multiple clients 
   to recieve notification when a change happens in the subject.
	
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural_Patterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Monitor a stock ticker, when particular events occur, react
            foreach (Stock s in SampleData.getNext())
            {
                // Reactive Filters
                if (s.Symbol == "GOOG")
                    Console.WriteLine("Google's new price is: {0}", s.Price);

                if (s.Symbol == "MSFT" && s.Price > 10.00m)
                    Console.WriteLine("Microsoft has reached the target price: {0}", s.Price);

                if (s.Symbol == "XOM")
                    Console.WriteLine("Exxon mobile's price is {0}", s.Price);
            }
        }
    }

    class SampleData
    {
        private static decimal[] samplePrices = new decimal[] { 10.00m, 10.25m, 555.55m, 9.50m, 9.03m, 500.00m, 499.99m, 10.10m };
        private static string[] sampleStocks = new string[] { "MSFT", "MSFT", "GOOG", "MSFT", "MSFT", "GOOG", "GOOG", "MSFT" };
        public static IEnumerable<Stock> getNext()
        {
            for (int i = 0; i < samplePrices.Length; i++)
            {
                Stock s = new Stock();
                s.Symbol = sampleStocks[i];
                s.Price = samplePrices[i];
                yield return s;
            }
        }

    }

    public class Stock
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
    }
}
