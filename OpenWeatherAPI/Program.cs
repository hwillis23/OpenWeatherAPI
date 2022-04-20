using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
     class Program
    {
        static void Main(string[] args)
        {
            var key = File.ReadAllText("appsettings.json");
            var client = new HttpClient();
            var apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();
               
            Console.WriteLine("Enter zip code");
            var zipcode = int.Parse(Console.ReadLine());
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipcode}&units=imperial&appid={apiKey}";
 
                var response = client.GetStringAsync(weatherURL).Result;
            var temp = double.Parse(JObject.Parse(response)["main"]["temp"].ToString());
              
                Console.WriteLine($"The current weather is {temp} F degrees.");
     

        }   
    }
}
