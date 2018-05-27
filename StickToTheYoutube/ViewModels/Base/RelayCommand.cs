using System;
using System.Windows.Input;

namespace StickToTheYoutube
{
    class RelayCommand : ICommand
    {
        private Action action;

        public RelayCommand(Action _action)
        {
            action = _action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
