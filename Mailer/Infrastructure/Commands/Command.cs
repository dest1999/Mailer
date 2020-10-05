using Mailer.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailer.Infrastructure.Commands
{
    class Command : BaseCommand
    {
        private readonly Action<object> _execute;

        private readonly Func<object, bool> _canExecute;

        public Command(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = CanExecute;
        }

        protected override bool CanExecute(object p) => _canExecute?.Invoke(p) ?? true;

        protected override void Execute(object p) => _execute(p);


    }
}
