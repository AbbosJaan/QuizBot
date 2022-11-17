using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBot.Models
{
    public class Answers
    {
        public string answer_a { get; set; }
        public string answer_b { get; set; }
        public string answer_c { get; set; }
        public string answer_d { get; set; }
    }

    public class CorrectAnswers
    {
        public string answer_a_correct { get; set; }
        public string answer_b_correct { get; set; }
        public string answer_c_correct { get; set; }
        public string answer_d_correct { get; set; }
    }

    public class Root
    {
        public int id { get; set; }
        public string question { get; set; }
        public object description { get; set; }
        public Answers answers { get; set; }
        public string multiple_correct_answers { get; set; }
        public CorrectAnswers correct_answers { get; set; }
        public string correct_answer { get; set; }
        public object explanation { get; set; }
        public object tip { get; set; }
        public List<Tag> tags { get; set; }
        public string category { get; set; }
        public string difficulty { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
    }


}
