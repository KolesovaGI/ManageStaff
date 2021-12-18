using System;
using System.Windows.Input;

namespace ManageStaffDBApp.Model
{
    /// <summary>
    /// Класс, содержащий команды для взаимодействия с программой
    /// </summary>
    public class RelayCommand: ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        /// <summary>
        /// Событие, вызывается при изменении условий, указывающее, может ли команда выполняться
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="execute">Выполнение команды</param>
        /// <param name="canExecute">Событие</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Определение, может ли команда выполняться
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
