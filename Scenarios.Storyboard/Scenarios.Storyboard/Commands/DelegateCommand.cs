using System;
using System.Windows.Input;

namespace Scenarios.Storyboard.Commands
{
    //Based on: http://www.wpftutorial.net/DelegateCommand.html
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _action;

        public DelegateCommand(Action<object> action) :
            this(action, null)
        {
        }

        public DelegateCommand(Action<object> action,
                               Predicate<object> canExecute)
        {
            _action = action;

            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
