using Prism.Mvvm;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using static Quiz.Models.QuestionsAndAnswers;

namespace Quiz.ViewModels
{
    public class EasyViewModel : BindableBase
    {
        public List<QuestionsAndAnswers> QuizQuestions = new List<QuestionsAndAnswers>();
        private void ReadDataBase()
        {
            XmlDataDocument xmlDataDocument = new XmlDataDocument();
            xmlDataDocument.Load(@"C:\Users\Ion Ml\source\repos\Quiz\Quiz\Models\Questions.xml");
            foreach(XmlNode node in xmlDataDocument.DocumentElement)
            {
                string QuestionName = node.Attributes[0].Value;
                string CorrectAnswer = node["CorrectAnswer"].Value;
                string WrongAnswer1 = node["WrongAnswer1"].Value;
                string WrongAnswer2 = node["WrongAnswer2"].Value;
                string WrongAnswer3 = node["WrongAnswer3"].Value;
                string Difficulty = node["Difficulty"].Value;
                if (Difficulty == "Easy")
                {
                    QuestionsAndAnswers questionsAndAnswers = new QuestionsAndAnswers(QuestionName, CorrectAnswer, WrongAnswer1, WrongAnswer2, WrongAnswer3, Difficulty);
                    QuizQuestions.Add(questionsAndAnswers);
                }
            }
        }
    }
}
