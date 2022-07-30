using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// Класс для авториации в источнике данных MS SQL
    /// </summary>
    public class AuthorizationMSSQLService : IAuthorizationService<AuthorizationMSSQLDataDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Событие оповещает о подключении к источнику данных
        /// </summary>
        public event IAuthorizationService<AuthorizationMSSQLDataDTO>.Connection? ConnectionEvent;
        /// <summary>
        /// Событие оповещает об отелючения от источника данных
        /// </summary>
        public event IAuthorizationService<AuthorizationMSSQLDataDTO>.Disconnection? DisconnectonEvent;

        public AuthorizationMSSQLService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Создает подключение к источнику данных
        /// </summary>
        /// <param name="dataAuthorization">Данные для подключения источнику данных</param>
        /// <returns>Асинхронная задача</returns>
        public async Task ConnectAsync(AuthorizationMSSQLDataDTO dataAuthorization)
        {
            try
            {
                await _unitOfWork.OrdersConnect.ConnectAsync(dataAuthorization.DataSourceName ?? "");
                ConnectionEvent?.Invoke(this, GetStatusConnect());
            }
            catch (Exception e) 
            {
                ConnectionEvent?.Invoke(this, GetStatusConnect());
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Отключает от источника данных
        /// </summary>
        /// <returns>Асинхронная задача</returns>
        public async Task DisconectAsync()
        {
            await _unitOfWork.OrdersConnect.DisconnectAsync();
            DisconnectonEvent?.Invoke(this, GetStatusConnect());
        }

        /// <summary>
        /// Запрашивает статус подключения к источнику данных
        /// </summary>
        /// <returns>Данные о поключении</returns>
        public DataConnectionDBDTO GetStatusConnect()
        {
            return new DataConnectionDBDTO()
            {
                DataSourceName = _unitOfWork.OrdersConnect.DatabaseName,
                IsConnect = _unitOfWork.OrdersConnect.IsEnabled,
            };
        }
    }
}
