using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Quiz.Helpers
{
    public static class DataModelHelper
    {
        private static readonly IList<QuestionAndAnswer> _quizQuestions;

        private static int _index;
        private const int _maxQuestionsToShow = 5;
        public static QuestionAndAnswer _currentQuestion;

        static DataModelHelper()
        {
            _quizQuestions = new List<QuestionAndAnswer>();
        }

        public static bool HasMultipleChoices => _currentQuestion.Answers.Where(x => x.IsValid).Count() > 1;

        public static void InitData(QuestionType questionType)
        {
            var xmlDataDocument = new XmlDocument();
            xmlDataDocument.Load(@"C:\\Users\\Ion Ml\\source\\repos\\Quiz\\Quiz\\Models\\Questions.xml");
            foreach (XmlNode questionNode in xmlDataDocument.DocumentElement)
            {
                if (string.Equals(questionNode.Name, questionType.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    var questionName = questionNode.Attributes[0].InnerText;

                    var answerNodeList = questionNode.ChildNodes;
                    var answerList = new List<Answer>();
                    foreach (XmlElement answerNode in answerNodeList)
                    {
                        var answerName = answerNode.InnerText;
                        var isValid = bool.Parse(answerNode.Attributes[0].InnerText);
                        var answer = new Answer(answerName, isValid);
                        answerList.Add(answer);
                    }

                    var questionsAndAnswer = new QuestionAndAnswer(questionName, answerList);
                    _quizQuestions.Add(questionsAndAnswer);
                }
            }
        }

        public static QuestionAndAnswer GetNextQuestion()
        {
            if (_index >= _maxQuestionsToShow || _index >= _quizQuestions.Count)
                return _currentQuestion; // check if null

            _currentQuestion = _quizQuestions.ElementAt(_index);
            _index++;
            return _currentQuestion;
        }
    }
}
