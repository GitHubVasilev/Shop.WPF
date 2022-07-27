using BusinessLogicLayer.DataTransferObject;

namespace BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса авторизация в источнике данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAuthorizationService<T> where T : BaseAuthorizationDB
    {
        delegate void Connection(IAuthorizationService<T> sender, DataConnectionDBDTO eventArgs);
        delegate void Disconnection(IAuthorizationService<T> sender, DataConnectionDBDTO eventArgs);

        /// <summary>
        /// Событие оповещающее о подключении к Источнику данных
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="eventArgs">Данны о подключении</param>
        public event Connection? ConnectionEvent;
        /// <summary>
        /// Событие оповещающее об отключении к Источнику данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public event Disconnection? DisconnectonEvent;
        /// <summary>
        /// Создает асинхронный запрос на подключение к источнику данных
        /// </summary>
        /// <param name="dataAuthorization">данные для создания подключения</param>
        /// <returns>асинхронная задача</returns>
        Task ConnectAsync(T dataAuthorization);
        /// <summary>
        /// Создает асинхронный запрос на отключения от источника данных
        /// </summary>
        /// <returns>Асинхронная задача</returns>
        Task DisconectAsync();
        /// <summary>
        /// Запрашивает статус подключения
        /// </summary>
        /// <returns>Данные о поключении</returns>
        DataConnectionDBDTO GetStatusConnect();
    }
}
