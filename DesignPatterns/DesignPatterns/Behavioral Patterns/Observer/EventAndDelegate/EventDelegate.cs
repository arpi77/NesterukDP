using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural_Patterns.EventAndDelegate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Monitor a stock ticker, when particular events occur, react
            StockTicker st = new StockTicker();

            // Create New observers to listen to the stock ticker
            GoogleMonitor gf = new GoogleMonitor(st);
            MicrosoftMonitor mf = new MicrosoftMonitor(st);

            // Load the Sample Stock Data
            foreach (var s in SampleData.getNext())
                st.Stock = s;
        }
    }

    class GoogleMonitor
    {
        public GoogleMonitor(StockTicker st)
        {
            st.StockChange += new EventHandler<StockChangeEventArgs>(st_StockChange);
        }

        void st_StockChange(object sender, StockChangeEventArgs e)
        {
            CheckFilter(e.Stock);
        }

        private void CheckFilter(Stock value)
        {
            if (value.Symbol == "GOOG")
                Console.WriteLine("Google's new price is: {0}", value.Price);
        }
    }

    class MicrosoftMonitor
    {
        public MicrosoftMonitor(StockTicker st)
        {
            st.StockChange += new EventHandler<StockChangeEventArgs>(st_StockChange);
        }

        void st_StockChange(object sender, StockChangeEventArgs e)
        {
            CheckFilter(e.Stock);
        }

        private void CheckFilter(Stock value)
        {
            if (value.Symbol == "MSFT" && value.Price > 10.00m)
                Console.WriteLine("Microsoft has reached the target price: {0}", value.Price);
        }
    }

    public class StockChangeEventArgs : EventArgs
    {
        public StockChangeEventArgs(Stock s)
        {
            this.Stock = s;
        }
        public Stock Stock { get; set; }
    }

    class StockTicker
    {
        private Stock stock;
        public Stock Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                this.OnStockChange(new StockChangeEventArgs(this.stock));
            }
        }

        public event EventHandler<StockChangeEventArgs> StockChange;

        protected virtual void OnStockChange(StockChangeEventArgs e)
        {
            if (StockChange != null)
            {
                StockChange(this, e);
            }
        }
    }
}
