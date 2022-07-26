using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Shop.WPF.ViewModel.Base
{
    /// <summary>
    /// Базовая модель представления с методами проверки данных
    ///  Реализует интерфейс <see cref="INotifyPropertyChanged"/>
    ///  Реализует интерфейс <see cref="INotifyDataErrorInfo"/>
    /// </summary>
    internal class ValidationBaseViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new();
        /// <summary>
        /// Указывает содержит ли модель ошибки
        /// </summary>
        public bool HasErrors => _errors.Count > 0;

        /// <summary>
        /// Указывает валидна ли VM. True - если валидна
        /// </summary>
        public bool IsValid => _errors.Count == 0;

        /// <summary>
        /// Событие о ошибке заполнения
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged = delegate { };

        /// <summary>
        /// Возвращает ошибки ввода данных для указанного свойства
        /// </summary>
        /// <param name="propertyName">Свойство</param>
        /// <returns>Список ошибок для свойства</returns>
        public IEnumerable GetErrors(string? propertyName)
        {
            return _errors.ContainsKey(propertyName ?? string.Empty) ? _errors[propertyName ?? string.Empty] : new List<string>();
        }

        public string GetErrorsString(string? propertyName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string field in GetErrors(propertyName)) 
            { stringBuilder.AppendLine(field); }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Устанавлиеат значение для свойства и оповещает об изменении
        /// </summary>
        /// <typeparam name="T">Тип свойства</typeparam>
        /// <param name="field">поле для заполнения</param>
        /// <param name="val">новое значение свойства</param>
        /// <param name="propertyName">Название свойства</param>
        /// <returns></returns>
        public override bool Set<T>(ref T field, T val, [CallerMemberName] string propertyName = "")
        {
            if (!base.Set(ref field, val, propertyName)) { return false; }
            ValidateProperty(propertyName, val);
            return true;
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {
            List<ValidationResult> results = new();

            ValidationContext context = new(this);
            context.MemberName = propertyName;
            _ = Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                _errors[propertyName] = results.Select(c => c.ErrorMessage).ToList()!;
            }
            else
            {
                _errors.Remove(propertyName);
            }

            ErrorsChanged!.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
