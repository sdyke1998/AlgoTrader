using System;
using System.Collections;
using System.Threading.Tasks;
using Alpaca.Markets;
using RestSharp;
using Newtonsoft.Json.Linq;
using Fynance;
using Fynance.Result;


namespace Bot{

    class InvalidTickerException : Exception{

        public InvalidTickerException(string symbol) : base("The ticker " + symbol + " has not been found. Have you spelled it correcty?"){}
    }

    class Startup{
        /**
         * File paths are obtained via a text file in the project directory that lists paths to files on my local machine.
         * If you download the project, you will need to change the paths.txt file to paths on your local machine.
         * Below is a list of indicies which correspond to what type of string/data is expected to be obtained.
         * This list will be changed to enums in the future, but for now they're hard-coded.
         * 
         * 0 : Path to txt file containing api keys. Secret key on line 1 and public key on line 2 in txt file.
         * 1 : Path to txt file containing a list of symbols to perform analysis on with historical data (not yet implemented).
        **/

        //When doing analysis with different symbols, use a file to read from. While we use a single symbol for testing, this variable is okay.
        const string _symbol = "AMD";
        
        public static void Main(string[] args){

            //The code here is for performing analysis on historical data.
            //The code in this if statement will run by default, when no command line arguments are entered.
            if (args.Length == 0){

                
            }

            //The following code is for performing trades and obtaining current market data using alpaca.
            //To execute this, you must type at least one command line argument. Any random string or single character will suffice.
            (string api_secret, string api_key) = ReadFromFile.APIKeys(0);
            else
            {
                ConnectOptions ops = new ConnectOptions();

                //Read from a file pls
                ops.SetURL("https://paper-api.alpaca.markets/v2/account");
                ops.AddHeaders([
                    ("accept", "application/json"),
                    ("APCA-API-KEY-ID", api_key),
                    ("APCA-API-SECRET-KEY", api_secret)
                ]);

                Connect connector = new Connect(api_key, api_secret, ops);
                connector.PrintBuyingPower();
            }
        }
    }
}