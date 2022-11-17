
using QuizBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizBot.GetAPiData
{
    public class GetApi
    {

        public void GetData()
        {
            string url = "https://quizapi.io/api/v1/questions?apiKey=1d9YRSbW5DDAj3kLidND6ocYotHzXB6fAofs29F3&limit=10&tags=HTML";

            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data  = JsonSerializer.Deserialize<List<Root>>(json);
        }
    }
}

