using System;
using System.Windows.Input;

namespace TsuShoWinApp
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool>? _canExecute;

        public RelayCommand(Action<object> execute)
        {
            this._execute = execute;
            this._canExecute = null;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// CanExecuteChangedは、イベントのサブスクリプションをCommandManager.RequerySuggestedイベントに委譲する。
        /// これにより、WPFのコマンドインフラストラクチャは、すべてのRelayCommandオブジェクトに実行可能かどうかを尋ねるようになる。
        /// これにより、WPFコマンドのインフラストラクチャは、すべてのRelayCommandオブジェクトに実行可能かどうかを尋ねる。
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null) 
            {
                return true;
            }

            if (parameter != null) 
            {
                return _canExecute(parameter);
            }

            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null) 
            {
                _execute(parameter);
            }
        }
    }
}
