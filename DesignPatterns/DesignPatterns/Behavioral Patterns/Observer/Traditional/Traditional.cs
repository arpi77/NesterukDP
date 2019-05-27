using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural_Patterns.Traditional
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Monitor a stock ticker, when particular events occur, react
            StockTicker subj = new StockTicker();

            // Create New observers to listen to the stock ticker
            GoogleObserver gobs = new GoogleObserver(subj);
            MicrosoftObserver mobs = new MicrosoftObserver(subj);

            // Load the Sample Stock Data
            foreach (var s in SampleData.getNext())
                subj.Stock = s;
        }

    }

    public abstract class AbstractObserver
    {
        public abstract void Update();
    }

    public abstract class AbstractSubject
    {
        List<AbstractObserver> observers = new List<AbstractObserver>();

        public void Register(AbstractObserver observer)
        {
            observers.Add(observer);
        }

        public void Unregister(AbstractObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in observers)
                o.Update();
        }
    }

    public class GoogleObserver : AbstractObserver
    {
        public GoogleObserver(StockTicker subj)
        {
            this.DataSource = subj;
            subj.Register(this);
        }
        private StockTicker DataSource { get; set; }
        public override void Update()
        {
            decimal price = DataSource.Stock.Price;
            string symbol = DataSource.Stock.Symbol;

            // Reactive Filters
            if (symbol == "GOOG")
                Console.WriteLine("Google's new price is: {0}", price);
        }
    }

    public class MicrosoftObserver : AbstractObserver
    {
        private StockTicker DataSource { get; set; }

        public MicrosoftObserver(StockTicker subj)
        {
            this.DataSource = subj;
            subj.Register(this);
        }

        public override void Update()
        {
            decimal price = DataSource.Stock.Price;
            string symbol = DataSource.Stock.Symbol;

            // Reactive Filters
            if (symbol == "MSFT" && price > 10.00m)
                Console.WriteLine("Microsoft has reached the target price: {0}", price);
        }
    }

    public class StockTicker : AbstractSubject
    {
        private Stock stock;
        public Stock Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                this.Notify();
            }
        }
    }
}
