using QuizBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace QuizBot.Broker
{
    internal class ApiBroker
    {
        private readonly string url = "https://quizapi.io/api/v1/questions?apiKey=KzpVFINjKqCXmo9tyx0xGPy5t6Mi75NTrBaKbtni&difficulty=Easy&limit=1&tags=MySQL";

        public static List<Root> GetData()
        {
            string url = "https://quizapi.io/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client
                .GetStringAsync($"api/v1/questions?apiKey=1d9YRSbW5DDAj3kLidND6ocYotHzXB6fAofs29F3&limit=10&tags=HTML").Result;
            var data = JsonConvert.DeserializeObject<List<Root>>(response);
            return data;
        }
    }
}
