using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class AuthorizationMSSQLService : IAuthorizationService<AuthorizationMSSQLDataDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public event IAuthorizationService<AuthorizationMSSQLDataDTO>.Connection? ConnectionEvent;
        public event IAuthorizationService<AuthorizationMSSQLDataDTO>.Disconnection? DisconnectonEvent;

        public AuthorizationMSSQLService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Connect(AuthorizationMSSQLDataDTO dataAuthorization)
        {
            await _unitOfWork.OrdersConnect.Connect(dataAuthorization.DataSourceName ?? "");
            ConnectionEvent?.Invoke(this, GetStatusConnect());
        }

        public async Task Disconect()
        {
            await _unitOfWork.OrdersConnect.Disconnect();
            DisconnectonEvent?.Invoke(this, GetStatusConnect());
        }

        public DataConnectionDBDTO GetStatusConnect()
        {
            return new DataConnectionDBDTO()
            {
                DataSourceName = _unitOfWork.OrdersConnect.DatabaseName,
                IsConnected = _unitOfWork.OrdersConnect.IsEnabled,
            };
        }
    }
}
