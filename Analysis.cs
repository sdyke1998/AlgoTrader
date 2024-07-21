using System;
using System.Collections;
using System.Threading.Tasks;
using Alpaca.Markets;
using RestSharp;
using Newtonsoft.Json.Linq;
using Fynance;
using Fynance.Result;

namespace Bot{

    class Analysis{
        
        public static void MovingAverageTracking(string symbol, int window, Period p = Period.ThreeMonths, Interval i = Interval.OneDay){

            List<FyQuote> prices;
            try{
                prices = Downloader.GetHistoricalData(symbol, p, i);
            }
            catch(InvalidTickerException te){
                string newSymbol;
                Console.WriteLine(te);
                Console.WriteLine("Please manually type a ticker symbol here. If the problem persists, check the GetSomeHistoricalData() method and recompile.");
                Console.Write("Ticker: ");
                newSymbol = Console.ReadLine();
                prices = Downloader.GetHistoricalData(newSymbol, p, i);
            }
            int n_prices = prices.Count;

            if(n_prices < window){//'n_prices' and 'window' depend on the timeframe of data obtained and cannot be arbitrarily chosen. Just stop program execution here.
                throw new ArgumentException("The historical data obtained is smaller than the window for the moving average.");
            }

            /*  
            This comment is the algorithm for calculating the moving average.

            1. Calcuate the moving average for each price points from the specified window
            2. At the latest price point, calcukate the latest moving average price
            3. If the moving average is between the latest price and the previous closing price, buy or sell, depending on whether the price is above the SMA or below
            Sidenote: test whether it's a buy or sell by testing whether the previous closing price was below the SMA or above

            */

            decimal SMA_prev = 0;
            for(int k = n_prices - 1; k > n_prices - window; k--){
                SMA_prev += prices[k].Close;
            }
            SMA_prev /= window; //(This is not complete for moving average, moving average is a line, not a point???) - Actually, not sure if this changes the analysis
            decimal SMA_next;
            
        }
    }
}