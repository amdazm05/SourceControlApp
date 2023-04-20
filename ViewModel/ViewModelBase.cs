using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;

namespace RFSourceControllerApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class RelayCommand : ICommand
        {
            private Action<object> _action;

            public RelayCommand(Action<object> action)
            {
                _action = action;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                if (parameter != null)
                {
                    _action(parameter);
                }
                else
                {
                    _action("Hello World");
                }
            }
        }

        public class DelegateCommand : ICommand
        {
            private readonly Action _action;
            private readonly Action<object> _actionWithParam;
            public event EventHandler CanExecuteChanged;
            public DelegateCommand(Action action)
            {
                _action = action;
                _actionWithParam = null;
            }

            public DelegateCommand(Action<object> action)
            {
                _actionWithParam = action;
                _action = null;
            }



            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _action?.Invoke();
                _actionWithParam?.Invoke(parameter);
            }
        }

        private Dictionary<string, string> _errors = new Dictionary<string, string>();



        #region Public Properties

        public bool HasErrors
        {
            get
            {
                return _errors.Count > 0;
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


        public void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName) || _errors[propertyName] != error)
            {
                _errors[propertyName] = error;
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public void RemoveError(string propertyName)
        {
            if (_errors.Remove(propertyName))
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public string GetError(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }

            return null;
        }

        public bool HasError(string propertyName)
        {
            return _errors.ContainsKey(propertyName);
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName == null)
                return null;

            List<string> err = new List<string>();
            if (_errors.ContainsKey(propertyName))
            {
                err.Add(_errors[propertyName]);
            }

            return err;
        }

        #endregion

    }

}
