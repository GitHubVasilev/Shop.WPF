using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class AuthorizationOleDBService : IAuthorizationService<AuthorizationOleDBDataDTO>
    {
        public void Connect(AuthorizationOleDBDataDTO dataAuthorization)
        {
            throw new NotImplementedException(message: "Ща все будет");
        }

        public void Disconect()
        {
            throw new NotImplementedException(message: "Ща все будет");
        }

        public DataConnectionDBDTO GetStatusConnect()
        {
            return new DataConnectionDBDTO() { DataSourceName="Pass", IsConnected=true };
        }
    }
}
