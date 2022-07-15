using BusinessLogicLayer.DataTransferObject;

namespace Shop.WPF.Interfaces
{
    /// <summary>
    /// Содержит информацию о подключении
    /// </summary>
    internal interface IConnectionProvider<T>
        where T : BaseAuthorizationDB
    {
        /// <summary>
        /// 0 - нет подключения
        /// 1 - есть подключение
        /// </summary>
        int IsConnect { get; }

        /// <summary>
        /// Имя подключения
        /// </summary>
        string? DataSourceName { get; }
    }
}
