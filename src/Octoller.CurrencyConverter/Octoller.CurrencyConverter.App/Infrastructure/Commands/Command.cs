using System;
using System.Windows.Input;

namespace Octoller.CurrencyConverter.App.Infrastructure.Commands
{
    public abstract class Command : ICommand
    {
        ///<inheritdoc />
        public event EventHandler CanExecuteChanged;

        ///<inheritdoc />
        public abstract bool CanExecute(object parameter);

        ///<inheritdoc />
        public abstract void Execute(object parameter);
    }
}
