using QuizBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBot.Broker
{
    internal interface IApiBroker
    {
        public  List<Root> GetData();
    }
}
