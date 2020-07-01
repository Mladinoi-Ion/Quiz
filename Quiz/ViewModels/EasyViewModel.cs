using Prism.Commands;
using Prism.Mvvm;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Xml;

namespace Quiz.ViewModels
{
    public class EasyViewModel : BindableBase
    {
        private readonly IList<QuestionsAndAnswer> _quizQuestions;

        private int _index;
        private const int _maxQuestionsToShow = 5;

        public EasyViewModel()
        {
            _quizQuestions = new List<QuestionsAndAnswer>();
            ReadDataBase();
            InitProperties();
        }

        private string _nameQuestion;
        public string NameQuestion
        {
            get => _nameQuestion;
            set => SetProperty(ref _nameQuestion, value);
        }

        private string _correctAnswer;
        public string CorrectAnswer
        {
            get => _correctAnswer;
            set => SetProperty(ref _correctAnswer, value);
        }

        private string _wrongAnswer1;
        public string WrongAnswer1
        {
            get => _wrongAnswer1;
            set => SetProperty(ref _wrongAnswer1, value);
        }

        private string _wrongAnswer2;
        public string WrongAnswer2
        {
            get => _wrongAnswer2;
            set => SetProperty(ref _wrongAnswer2, value);
        }

        private string _wrongAnswer3;
        public string WrongAnswer3
        {
            get => _wrongAnswer3;
            set => SetProperty(ref _wrongAnswer3, value);
        }

        private ICommand _buttonNextCommand;
        public ICommand ButtonNextCommand => _buttonNextCommand ??= new DelegateCommand(Execute);

        private void ReadDataBase()
        {
            var xmlDataDocument = new XmlDocument();
            xmlDataDocument.Load(@"C:\\Users\\Ion Ml\\source\\repos\\Quiz\\Quiz\\Models\\Questions.xml");
            foreach (XmlNode node in xmlDataDocument.DocumentElement)
            {
                var questionName = node.Attributes[0].InnerText;
                var difficulty = Enum.Parse<DifficultyType>(node.Attributes[1].InnerText, true);

                //var answerNodeList = node["Answer"].ChildNodes;
                var answerNodeList = node.ChildNodes;
                var answerList = new List<Answer>();
                foreach (XmlElement answerNode in answerNodeList)
                {
                    var answerName = answerNode.InnerText;
                    var isValid = bool.Parse(answerNode.Attributes[0].InnerText);
                    var answer = new Answer(answerName, isValid);
                    answerList.Add(answer);
                }

                var questionsAndAnswer = new QuestionsAndAnswer(questionName, difficulty, answerList);
                _quizQuestions.Add(questionsAndAnswer);
            }
        }

        private void InitProperties()
        {
            if (!_quizQuestions.Any())
                return;

            NameQuestion = _quizQuestions.First().Name;
            //CorrectAnswer = _quizQuestions.First().CorrectAnswer;
            //WrongAnswer1 = _quizQuestions.First().WrongAnswer1;
            //WrongAnswer2 = _quizQuestions.First().WrongAnswer2;
            //WrongAnswer3 = _quizQuestions.First().WrongAnswer3;
            _index++;
        }

        private void Execute()
        {
            if (_index >= _maxQuestionsToShow || _index >= _quizQuestions.Count)
                return;

            //var nextQuestion = _quizQuestions.ElementAt(_index);
            //NameQuestion = nextQuestion.Name;
            //CorrectAnswer = nextQuestion.CorrectAnswer;
            //WrongAnswer1 = nextQuestion.WrongAnswer1;
            //WrongAnswer2 = nextQuestion.WrongAnswer2;
            //WrongAnswer3 = nextQuestion.WrongAnswer3;
            _index++;
        }
    }
}