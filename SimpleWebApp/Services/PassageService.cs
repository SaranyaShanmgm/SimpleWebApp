using SimpleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp.Services
{
    public class PassageService : IPassageService
    {
        public Passage GetPassage(int passageId)
        {
            var passage =  new Passage
            {
                PassageId = 1,
                Title = "The Great Wall",
                Query = "The Great Wall",
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/c/cd/The_Great_Wall_%28film%29.png",
                Description = "The Great Wall (Chinese: 长城) is a 2016 Chinese fantasy action monster film directed by Zhang Yimou, with a screenplay by Carlo Bernard, Doug Miro and Tony Gilroy, from a story by Max Brooks, Edward Zwick and Marshall Herskovitz. It is an American and Chinese co-production starring Matt Damon, Jing Tian, Pedro Pascal, Willem Dafoe, and Andy Lau. The Great Wall is Zhang's first English-language film.[7] Principal photography for the film began on March 30, 2015, in Qingdao, China, and it premiered in Beijing on December 6, 2016.It was released by China Film Group in China on December 16, 2016, and in the United States on February 17, 2017 by Universal Pictures.The film received mixed reviews from critics, who said it \"sacrifices great story for great action.\"[8] Although it grossed $335 million worldwide, the film was still considered a box office bomb due to its high production and marketing costs, with losses as high as $75 million."
            };

            var question1 = new Question
            {
                QuestionId = 1,
                QuestionName = "How is the entity on the right panel relevant to the query?",
                QuestionType = QuestionType.SingleChoice,
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Name = "Excellent", Rank = 1, Value = 100 },
                    new QuestionOption { Name = "Good", Rank = 4, Value = 50 },
                    new QuestionOption { Name = "Poor", Rank = 10, Value = 0 }
                }
            };

            var question2 = new Question
            {
                QuestionId = 2,
                QuestionName = "Which parts of the content is relevant to the query?",
                QuestionType = QuestionType.MultipleChoice,
                Options = new List<QuestionOption>
                {
                    new QuestionOption { Name = "Image", Rank = 1, Value = 50 },
                    new QuestionOption { Name = "Name", Rank = 4, Value = 50 },
                    new QuestionOption { Name = "Description", Rank = 10, Value = 25}
                }
            };

            passage.Questions = new List<Question> { question1, question2 };

            return passage;
        }
    }
}
