using Prism.Commands;
using Prism.Mvvm;
using Quiz.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Quiz.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _Name = "Mladinoi Ion";
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private bool _EasyIsEnabled;

        public bool EasyIsEnabled
        {
            get { return _EasyIsEnabled; }
            set { SetProperty(ref _EasyIsEnabled, value); }
        }

        public DelegateCommand StartQuiz { get; private set; }

        public MainWindowViewModel()
        {
            StartQuiz = new DelegateCommand(Execute, CanExecute);
        }

        private void Execute()
        {
            if (EasyIsEnabled)
            {
                EasyView easyView = new EasyView();
                easyView.Show();
            }
        }

        private bool CanExecute()
        {
            return true;
        }
    }
}
