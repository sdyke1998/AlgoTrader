using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using Fynance;
using Fynance.Result;

namespace Bot{

    using Header = (string title, string value);

    class ConnectOptions{
        
        public List<Header> headers;
        public string URL {get; set;}

        public ConnectOptions(){
            headers = new List<Header>();
        }

        public ConnectOptions AddHeader(Header header){
            headers.Add(header);
            return this;
        }
        public ConnectOptions AddHeaders(Header[] _headers){
            foreach(Header header in _headers){
                headers.Add(header);
            }
            return this;
        }

        public ConnectOptions SetURL(string url){
            this.URL = url;
            return this;
        }
        
    }

    class Connect{

        private string api_key;
        private string api_secret;
        public ConnectOptions connectOptions {private get; set;}

        public Connect(string api_key, string api_secret, ConnectOptions connectOptions){
            this.api_key = api_key;
            this.api_secret = api_secret;
            this.connectOptions = connectOptions;
        }

        JObject Get(){
            
            //Remember to turn this block of code for retreiving RESTful response into a method
            var options = new RestClientOptions(connectOptions.URL);
            var client = new RestClient(options);

            var request = new RestRequest();
            foreach(Header header in connectOptions.headers){
                request.AddHeader(header.title, header.value);
            }

            var response = client.Get(request);
            //Are you sure that RestSharp doesn't have a mechanism for dealing with JSON responses?
            JObject json_response = JObject.Parse(response.Content);
            return json_response;            
        }

        void Send(){

        }

        void Delete(){

        }

        public void PrintBuyingPower(){
            
            var response = this.Get();
            Console.WriteLine(response["buying_power"]);
        }
    }
}