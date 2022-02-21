using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://reqres.in/");
            //var request = new RestRequest("api/users?page=2", Method.GET);
            //request.AddHeader("Accept", "application/json");
            //request.RequestFormat = DataFormat.Json;

            //IRestResponse response = client.Execute(request);
            //var content = response.Content;
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
