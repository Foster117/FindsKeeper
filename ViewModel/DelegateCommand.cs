using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    class DelegateCommand : ICommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;
        private ICommand removeCommand;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                return canExecute(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }

        public DelegateCommand(Action<object> executeAction) : this(executeAction, null)
        {

        }
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            canExecute = canExecuteFunc;
            execute = executeAction;
        }

        public DelegateCommand(ICommand removeCommand)
        {
            this.removeCommand = removeCommand;
        }
    }
}
