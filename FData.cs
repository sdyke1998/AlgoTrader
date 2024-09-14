using System;
using System.Collections;
using System.Threading.Tasks;
using Fynance;
using Fynance.Result;
using System.IO;

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

    static class ReadFromFile{

        public static string IndexToPath(int index)
        {
            /**
             * This algorithm of looping through all listed file paths may be more efficiently implemented by using File.ReadLines.
             * File.ReadLines returns a lazy evaluated IEnumerable<string> (does not load entire text file).
             **/

            string path;
            int count = 0;
            using TextReader readah = new StreamReader(new FileStream("paths.txt", FileMode.Open, FileAccess.Read));
            {
                while(count < index) 
                {
                    readah.ReadLine();
                    count++;
                }
                path = readah.ReadLine();
                return path;
            }
        }

        public static (string _secret, string _key) APIKeys(int index)
        {
            string path = IndexToPath(index);
            using FileStream api_ = File.Open(path, FileMode.Open, FileAccess.Read);
            using TextReader readah = new StreamReader(api_);
            {
                string _secret = readah.ReadLine();
                string _key = readah.ReadLine();
                return (_secret, _key);
            }
        }
    }
}