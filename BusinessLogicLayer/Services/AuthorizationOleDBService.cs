using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class AuthorizationOleDBService : IAuthorizationService<AuthorizationOleDBDataDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public event IAuthorizationService<AuthorizationOleDBDataDTO>.Connection? ConnectionEvent;
        public event IAuthorizationService<AuthorizationOleDBDataDTO>.Disconnection? DisconnectonEvent;

        public AuthorizationOleDBService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Connect(AuthorizationOleDBDataDTO dataAuthorization)
        {
            await _unitOfWork.CustomrsConnect.Connect(
                dataAuthorization.DataSourceName ?? "",
                dataAuthorization.Login ?? "",
                dataAuthorization.Password ?? "");
            ConnectionEvent?.Invoke(this, GetStatusConnect());
        }

        public async Task Disconect()
        {
            await _unitOfWork.CustomrsConnect.Disconnect();
            DisconnectonEvent?.Invoke(this, GetStatusConnect());
        }

        public DataConnectionDBDTO GetStatusConnect()
        {
            return new DataConnectionDBDTO()
            {
                DataSourceName = _unitOfWork.CustomrsConnect.DatabaseName,
                IsConnected = _unitOfWork.CustomrsConnect.IsEnabled
            };
        }
    }
}
