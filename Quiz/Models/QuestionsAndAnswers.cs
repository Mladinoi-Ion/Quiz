using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class QuestionsAndAnswers
    {
        public string QuestionName { get; private set; }
        public string CorrectAnswer { get; private set; }
        public string WrongAnswer1 { get; private set; }
        public string WrongAnswer2 { get; private set; }
        public string WrongAnswer3 { get; private set; }
        public string Difficulty { get; private set; }

        public QuestionsAndAnswers(string questionName, string correctAnswer, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string difficulty)
        {
            QuestionName = questionName;
            CorrectAnswer = correctAnswer;
            WrongAnswer1 = wrongAnswer1;
            WrongAnswer2 = wrongAnswer2;
            WrongAnswer3 = wrongAnswer3;
            Difficulty = difficulty;
        }
    }
}
