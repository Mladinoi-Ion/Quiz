using Prism.Mvvm;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.ViewModels
{
    public class BaseChoiceViewModel : BindableBase
    {
        private string _currentQuestionName;
        public string CurrentQuestionName
        {
            get => _currentQuestionName;
            set => SetProperty(ref _currentQuestionName, value);
        }

        private IEnumerable<Answer> _currentAnswers;
        public IEnumerable<Answer> CurrentAnswers
        {
            get => _currentAnswers;
            set => SetProperty(ref _currentAnswers, value);
        }
    }
}
