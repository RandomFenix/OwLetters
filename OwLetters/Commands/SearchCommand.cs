using System;
using System.Windows.Input;

namespace OwLetter.Commands
{
    public class SearchCommand : ICommand
    {
        public Action execute;
        public SearchCommand(Action execute)
        {
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute.Invoke();
        }
    }
}
