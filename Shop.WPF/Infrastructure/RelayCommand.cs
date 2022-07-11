using System;
using System.Windows.Input;

namespace Shop.WPF.Infrastructure
{
    /// <summary>
    /// Класс для работы с командами в xaml разметке
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        /// <summary>
        /// Событие, вызывается при изменении условий выполнения команды
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null!)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Определяет, может ли команда выполняться
        /// </summary>
        /// <param name="parameter">Данные, используемые командой.
        /// Если в команду не передаются данные parameter может быть null</param>
        /// <returns>true - если команда может быть выполнена</returns>
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter!);
        }

        /// <summary>
        /// Определяет метод, который будет вызван при вызов команды
        /// </summary>
        /// <param name="parameter">Данные, используемые командой.
        /// Если в команду не передаются данные parameter может быть null</param>
        public void Execute(object? parameter)
        {
            execute(parameter!);
        }
    }
}
