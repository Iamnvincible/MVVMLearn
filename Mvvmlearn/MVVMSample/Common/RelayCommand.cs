﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMSample.Common
{
    public class RelayCommand:ICommand
    {

        public event EventHandler CanExecuteChanged;
        private readonly Action<object> _targetExecuteMethod;
        private readonly Predicate<object> _targetCanExecuteMethod;

        public bool CanExecute(object parameter)
        {
            return _targetCanExecuteMethod == null || _targetCanExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            if (_targetExecuteMethod != null)
                _targetExecuteMethod(parameter);
        }
        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod = null)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
