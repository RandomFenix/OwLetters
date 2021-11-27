using System;
using System.Windows.Input;

namespace OwLetter.Commands
{
    public class ShiftCommand : ICommand
    {
        public Action execute;
        public ShiftCommand(Action execute)
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
