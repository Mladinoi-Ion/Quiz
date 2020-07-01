using Prism.Commands;
using Prism.Mvvm;
using Quiz.Models;
using Quiz.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Xml;

namespace Quiz.ViewModels
{
    public class QuizViewModel : BindableBase
    {
        private readonly IList<QuestionAndAnswer> _quizQuestions;

        private int _index;
        private QuestionType _questionType;
        private const int _maxQuestionsToShow = 5;

        public QuizViewModel(QuestionType questionType)
        {
            _questionType = questionType;
            _quizQuestions = new List<QuestionAndAnswer>();
            ReadDataBase();
            InitProperties();
        }

        private BaseChoiceViewModel _currentViewModel;
        public BaseChoiceViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        private ICommand _buttonNextCommand;
        public ICommand ButtonNextCommand => _buttonNextCommand ??= new DelegateCommand(Execute, () => true);

        private void ReadDataBase()
        {
            var xmlDataDocument = new XmlDocument();
            xmlDataDocument.Load(@"C:\\Users\\Ion Ml\\source\\repos\\Quiz\\Quiz\\Models\\Questions.xml");
            foreach (XmlNode questionNode in xmlDataDocument.DocumentElement)
            {
                if (string.Equals(questionNode.Name, _questionType.ToString(), StringComparison.OrdinalIgnoreCase))
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

                    var questionsAndAnswer = new QuestionAndAnswer(questionName, DifficultyType.Easy, answerList);
                    _quizQuestions.Add(questionsAndAnswer);
                }
            }
        }

        private void InitProperties()
        {
            if (!_quizQuestions.Any())
                return;

            var currentQuestion = _quizQuestions.First();
            InitCurrentViewModel(currentQuestion);
            _index++;
        }

        private void Execute()
        {
            if (_index >= _maxQuestionsToShow || _index >= _quizQuestions.Count)
                return;

            var currentQuestion = _quizQuestions.ElementAt(_index);
            InitCurrentViewModel(currentQuestion);
            _index++;
        }

        private void InitCurrentViewModel(QuestionAndAnswer currentQuestion)
        {
            if (currentQuestion.Answers.Where(x => x.IsValid).Count() > 1)
            {
                CurrentViewModel = new MultipleChoicesViewModel();
            }
            else
            {
                CurrentViewModel = new SingleChoiceViewModel();

            }
            CurrentViewModel.CurrentQuestionName = currentQuestion.Name;
            CurrentViewModel.CurrentAnswers = currentQuestion.Answers;
        }
    }
}