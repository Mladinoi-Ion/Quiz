using Prism.Mvvm;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.ViewModels
{
    public class MultipleChoicesViewModel : BaseChoiceViewModel
    {
        public MultipleChoicesViewModel(QuestionAndAnswer questionAndAnswer)
            : base(questionAndAnswer)
        {
        }
    }
}
