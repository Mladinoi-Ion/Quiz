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
        private string _Name = "Ion Mladinoi";
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        public ICommand ButtonCommand { get; set; }

        public MainWindowViewModel()
        {
            ButtonCommand = new RelayCommand(new Action<object>(ShowWindow));
        }

        public void ShowWindow(object obj)
        {
            if (obj.ToString() == "Easy")
            {
                EasyView easyView = new EasyView();
                easyView.Show();
            }
        }

        internal class RelayCommand : ICommand
        {
            private Action<object> _action;
            public RelayCommand(Action<object> action)
            {
                _action = action;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                if (parameter != null)
                {
                    _action(parameter);
                }
            }
        }
    }
}
