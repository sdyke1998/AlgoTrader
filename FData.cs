using System;
using System.Collections;
using System.Threading.Tasks;
using Fynance;
using Fynance.Result;

namespace Bot{

    class Downloader{

        public static List<FyQuote> GetHistoricalData(string symbol, Period p = Period.OneYear, Interval i = Interval.OneMonth){
         
            var result = Ticker.Build().SetSymbol(symbol)
                                             .SetPeriod(p)
                                             .SetInterval(i)
                                             .Get();
            
            if(result == null){
                throw new InvalidTickerException(symbol);
            }
            else{
                return new List<FyQuote>(result.Quotes);
            }
        }
    }
}