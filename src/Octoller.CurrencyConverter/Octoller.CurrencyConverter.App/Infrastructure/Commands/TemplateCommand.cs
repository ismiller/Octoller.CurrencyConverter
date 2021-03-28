using System;

namespace Octoller.CurrencyConverter.App.Infrastructure.Commands
{
    public class TemplateCommand : Command
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        ///<inheritdoc />
        public TemplateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        ///<inheritdoc />
        public override bool CanExecute(object parameter) =>
            canExecute?.Invoke(parameter) ?? true;

        ///<inheritdoc />
        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            execute?.Invoke(parameter);
        }
    }
}
