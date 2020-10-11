using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public QuestionType QuestionType { get; set; }
        public IList<QuestionOption> Options  {get; set;}
    }
}
