using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BE_CodingChal;
using Newtonsoft.Json;
using RestSharp;

namespace ADO_CodingChal
{
    public class ado_response
    {
        public void GetResult(string query)
        {
            string[] queries;
            Dictionary<string, Int64> lstGoogle = new Dictionary<string, Int64>();
            Dictionary<string, Int64> lstBing = new Dictionary<string, Int64>();
            Dictionary<string, Int64> lstWinner = new Dictionary<string, Int64>();

            if (!query.Contains("\""))
            {
                queries = query.Split(char.Parse(" "));
            }
            else
            {
                queries = new string[] { query };
                queries= query.Split(char.Parse("\""));
            }
            
            foreach(string val in queries)
             {
                if (val.Trim().Replace(" ",string.Empty) != string.Empty)
                {
                    string vv = val.Trim().Replace(" ", "+");
                    var url = @"https://www.googleapis.com/customsearch/v1?key=AIzaSyA8RDBlx64rbLgc8zUId5q2sWU-coTj3fw&cx=017576662512468239146:omuauf_lfve&q=" + val.Trim().Replace(" ","+");

                    try
                    {
                        //GOOGLE
                        var client = new RestClient(url);
                        var request = new RestRequest(Method.GET);
                        IRestResponse response = client.Execute(request);
                        be_response.be_response_google _be_google = new be_response.be_response_google();
                        _be_google = JsonConvert.DeserializeObject<be_response.be_response_google>(response.Content);
                        Int64.TryParse(_be_google.searchInformation.totalResults.Trim(), out Int64 rGoogle);
                        lstGoogle.Add(val, rGoogle);

                        //BING
                        client = new RestClient("https://api.bing.microsoft.com/v7.0/search?q="+ val.Trim().Replace(" ", "+"));
                        var req = new RestRequest(Method.GET);
                        req.AddHeader("Ocp-Apim-Subscription-Key", "855f97d396654ef781aad8f25b185821");
                        response = client.Execute(req);
                        be_response.be_response_bing _be_bing = new be_response.be_response_bing();
                        _be_bing = JsonConvert.DeserializeObject<be_response.be_response_bing>(response.Content);
                        Int64.TryParse(_be_bing.WebPages.totalEstimatedMatches, out Int64 rBing);
                        lstBing.Add(val, rBing);

                        lstWinner.Add(val, rGoogle + rBing);

                        Console.WriteLine(val + "--> Google:" + rGoogle + ",Bing Search:" + rBing);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            //max value
            var maxGoogle = lstGoogle.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            var maxBing = lstBing.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            Console.WriteLine("Google winner: " + maxGoogle);
            Console.WriteLine("Bing winner: " + maxBing);

            //total winner
            var totalWinner = lstWinner.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            Console.WriteLine("Total Winner: " + totalWinner);
        }
    }
}
