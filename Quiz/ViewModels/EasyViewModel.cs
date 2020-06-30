using Prism.Commands;
using Prism.Mvvm;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using System.Xml;
using static Quiz.Models.QuestionsAndAnswers;
using Quiz.Views;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Quiz.ViewModels
{
    public class EasyViewModel : BindableBase
    {
        public List<QuestionsAndAnswers> QuizQuestions = new List<QuestionsAndAnswers>();

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

        int index = 1;

        public string _NameQuestion;
        public string _CorrectAnswer;
        public string _WrongAnswer1;
        public string _WrongAnswer2;
        public string _WrongAnswer3;

        public DelegateCommand ButtonNext { get; private set; }

        public EasyViewModel()
        {
            ReadDataBase();
            QuestionsAndAnswers values = QuizQuestions[0];
            _NameQuestion = values.QuestionName;
            _CorrectAnswer = values.CorrectAnswer;
            _WrongAnswer1 = values.WrongAnswer1;
            _WrongAnswer2 = values.WrongAnswer2;
            _WrongAnswer3 = values.WrongAnswer3;
            ButtonNext = new DelegateCommand(Execute, CanExecute);
        }

        private void Execute()
        {
           for (int i = 1; i < QuizQuestions.Count; i++)
           {
                if (index == i)
                {
                    QuestionsAndAnswers values = QuizQuestions[i];
                    _NameQuestion = values.QuestionName;
                    _CorrectAnswer = values.CorrectAnswer;
                    _WrongAnswer1 = values.WrongAnswer1;
                    _WrongAnswer2 = values.WrongAnswer2;
                    _WrongAnswer3 = values.WrongAnswer3;
                    NameQuestion = $" {_NameQuestion}";
                    Correct_Answer = $" {_CorrectAnswer}";
                    Wrong_Answer1 = $" {_WrongAnswer1}";
                    Wrong_Answer2 = $" {_WrongAnswer2}";
                    Wrong_Answer3 = $" {_WrongAnswer3}";
                }
            }
            ++index;
        }

        private bool CanExecute()
        {
            return true;
        }

        public string NameQuestion
        {
            get { return _NameQuestion; }
            set { SetProperty(ref _NameQuestion, value); }
        }

        public string Correct_Answer
        {
            get { return _CorrectAnswer; }
            set { SetProperty(ref _CorrectAnswer, value); }
        }

        public string Wrong_Answer1
        {
            get { return _WrongAnswer1; }
            set { SetProperty(ref _WrongAnswer1, value); }
        }

        public string Wrong_Answer2
        {
            get { return _WrongAnswer2; }
            set { SetProperty(ref _WrongAnswer2, value); }
        }

        public string Wrong_Answer3
        {
            get { return _WrongAnswer3; }
            set { SetProperty(ref _WrongAnswer3, value); }
        }
    }
}