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
        
        //read from a file pls
        const string api_secret = "34Xs99haNRgj49oAGupnb2XCW3VBrdsr8DwEA64q";
        const string api_key = "PK6E8BMY1CQ42EYQ533T";

        const string _symbol = "AMD";
        
        public static void Main(string[] args){

            if(args.Length == 0){
                
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
            else{ // IMPORTANT: Implement a framrate here or else you will run out of API calls

                Analysis.MovingAverageTracking(_symbol, 5);
            }
        }
    }
}