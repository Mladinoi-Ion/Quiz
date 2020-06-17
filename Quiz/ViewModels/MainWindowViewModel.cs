using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _Name = "Ion";
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
    }
}
