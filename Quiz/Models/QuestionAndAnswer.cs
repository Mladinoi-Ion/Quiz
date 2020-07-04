using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class QuestionAndAnswer
    {
        public string Name { get; private set; }
        public IEnumerable<Answer> Answers { get; set; }

        public QuestionAndAnswer(string name, IEnumerable<Answer> answers)
        {
            Name = name;
            Answers = answers;
        }
    }
}
