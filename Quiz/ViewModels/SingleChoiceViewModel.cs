using Prism.Mvvm;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.ViewModels
{
    public class SingleChoiceViewModel : BaseChoiceViewModel
    {
        public SingleChoiceViewModel(QuestionAndAnswer questionAndAnswer)
            : base(questionAndAnswer)
        {
        }
    }
}
