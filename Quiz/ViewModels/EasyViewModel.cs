using Prism.Mvvm;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using System.Xml;
using static Quiz.Models.QuestionsAndAnswers;

namespace Quiz.ViewModels
{
    public class EasyViewModel : BindableBase
    {
        public List<QuestionsAndAnswers> QuizQuestions = new List<QuestionsAndAnswers>();

        public string _NameQuestion;
        public void ReadDataBase()
        {
            XmlDataDocument xmlDataDocument = new XmlDataDocument();
            xmlDataDocument.Load(@"C:\\Users\\Ion Ml\\source\\repos\\Quiz\\Quiz\\Models\\Questions.xml");
            foreach (XmlNode node in xmlDataDocument.DocumentElement)
            {
                string QuestionName = node.Attributes[0].InnerText;
                string CorrectAnswer = node["CorrectAnswer"].InnerText;
                string WrongAnswer1 = node["WrongAnswer1"].InnerText;
                string WrongAnswer2 = node["WrongAnswer2"].InnerText;
                string WrongAnswer3 = node["WrongAnswer3"].InnerText;
                string Difficulty = node["Difficulty"].InnerText;
                if (Difficulty.Equals("Easy"))
                {
                    QuestionsAndAnswers questionsAndAnswers = new QuestionsAndAnswers(QuestionName, CorrectAnswer, WrongAnswer1, WrongAnswer2, WrongAnswer3, Difficulty);
                    QuizQuestions.Add(questionsAndAnswers);
                }
            }
        }

        public EasyViewModel()
        {
            ReadDataBase();
            for (int i = 0; i < QuizQuestions.Count; i++)
            {
                QuestionsAndAnswers values = QuizQuestions[i];
                _NameQuestion = values.QuestionName;
            }
        }
        public string NameQuestion
        {
            get { return _NameQuestion; }
            set { SetProperty(ref _NameQuestion, value); }
        }
    }
}


