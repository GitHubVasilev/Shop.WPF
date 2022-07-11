using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shop.WPF.ViewModel.Base
{
    /// <summary>
    /// Содержит методы для уведомления слушателей свойств моделей-представления.
    /// Реализует интерфейс <see cref="INotifyPropertyChanged"/>
    /// </summary>
    internal class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// событие для уведомления об изменении свойств
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Уведомляет слушателей об изменении свойства
        /// </summary>
        /// <param name="prop">Название свойства, которое используется для уведомления слушателя</param>
        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Изменят поле <paramref name="field"/> на значение <paramref name="value"/>. Уведомляет слушателей об изменении
        /// Проверяет на равенство <paramref name="value"/> и старое значение. Если они равны, изменения не произойдет
        /// </summary>
        /// <typeparam name="T">Тип свойства</typeparam>
        /// <param name="field">ссылка на изменяемое поле</param>
        /// <param name="value">новое значения поля</param>
        /// <param name="prop">Название свойства, которое используется для уведомления слушателя</param>
        /// <returns>True - если свойство было изменено. False - если изменение не произошло</returns>
        public virtual bool Set<T>(ref T field, T value, [CallerMemberName] string prop = "")
        {
            if (Equals(field, value)) { return false; }
            field = value;
            OnPropertyChanged(prop);
            return true;
        }
    }
}
