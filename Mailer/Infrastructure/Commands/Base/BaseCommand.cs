﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Mailer.Infrastructure.Commands.Base
{
    abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        bool ICommand.CanExecute(object parameter) => CanExecute(parameter);
        void ICommand.Execute(object parameter) => Execute(parameter);
        protected virtual bool CanExecute(object p) => true;
        protected abstract void Execute(object p);
    }
}
