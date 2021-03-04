using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DepsWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace PrimeNumberTest
{
    static class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            using (var fs = new FileStream("TestUri.json", FileMode.Open))
            {
                client.BaseAddress = new Uri((await JsonSerializer.DeserializeAsync<UriModel>(fs)).Uri);
            }
            await TestExeption("/register", "401 Exception: 2");
            await Test("/Rates/UAH/USD", "200 result: 0.03");
            await Test("/Rates/UAH/USD?amount=100", "200 result: 3.6");
            Console.ReadKey();
        }
        
        public static async Task TestExeption(string uri,string expected)
        {
            var content = new StringContent(JsonSerializer.Serialize(new RegisterModel("login", "password")), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri,content);
            Console.WriteLine($"Expected: \t{expected}");
            var str = await response.Content.ReadAsStringAsync();

            var ex = JsonSerializer.Deserialize<ExceptionModel>(str,new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });
            Console.WriteLine($"Get: \t\t{(int)response.StatusCode} Exception: {ex.Code} {ex.Message }");
        }
        public static async Task Test(string uri, string expected)
        {
            var response = await client.GetAsync(uri);
            Console.WriteLine($"Send: {client.BaseAddress + uri}");
            Console.WriteLine($"Expected: \t{expected}");
            var ex = await JsonSerializer.DeserializeAsync<decimal>(await response.Content.ReadAsStreamAsync());
            Console.WriteLine($"Get: \t\t{(int)response.StatusCode} result: {ex }");
        }
    }
}
