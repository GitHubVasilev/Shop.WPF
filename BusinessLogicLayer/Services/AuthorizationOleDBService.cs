using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// Класс для авторизации в источнике данных MS Access
    /// </summary>
    public class AuthorizationOleDBService : IAuthorizationService<AuthorizationOleDBDataDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Событие оповещающее о подключении к источнику данных
        /// </summary>
        public event IAuthorizationService<AuthorizationOleDBDataDTO>.Connection? ConnectionEvent;
        /// <summary>
        /// Событие оповещающее об отключении от источника данных
        /// </summary>
        public event IAuthorizationService<AuthorizationOleDBDataDTO>.Disconnection? DisconnectonEvent;

        public AuthorizationOleDBService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Асинхронный метод запрос на подключение к источнику данных
        /// </summary>
        /// <param name="dataAuthorization">Данные для подключения к источнику данных</param>
        /// <returns>Асинхронная задача</returns>
        public async Task ConnectAsync(AuthorizationOleDBDataDTO dataAuthorization)
        {
            await _unitOfWork.CustomrsConnect.ConnectAsync(
                dataAuthorization.DataSourceName ?? "",
                dataAuthorization.Login ?? "",
                dataAuthorization.Password ?? "");
            ConnectionEvent?.Invoke(this, GetStatusConnect());
        }

        /// <summary>
        /// Асинхронный метод Создает запрос на отключения от источника дынных
        /// </summary>
        /// <returns>Асинхронная задача</returns>
        public async Task DisconectAsync()
        {
            await _unitOfWork.CustomrsConnect.DisconnectAsync();
            DisconnectonEvent?.Invoke(this, GetStatusConnect());
        }

        /// <summary>
        /// Создает запрос о статусе подклчения
        /// </summary>
        /// <returns>Данные о подключении</returns>
        public DataConnectionDBDTO GetStatusConnect()
        {
            return new DataConnectionDBDTO()
            {
                DataSourceName = _unitOfWork.CustomrsConnect.DatabaseName,
                IsConnect = _unitOfWork.CustomrsConnect.IsEnabled
            };
        }
    }
}
