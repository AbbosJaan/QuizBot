
using Newtonsoft.Json;
using QuizBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace QuizBot.GetAPiData
{
    public class GetApi
    {

        public Root GetData()
        {
            string url = "https://quizapi.io/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response =  client
                .GetStringAsync($"api/v1/questions?apiKey=1d9YRSbW5DDAj3kLidND6ocYotHzXB6fAofs29F3&limit=1&tags=HTML").Result;
            var data = JsonConvert.DeserializeObject<List<Root>>(response);
            return data[0];
                
        }
    }
}

