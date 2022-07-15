using BusinessLogicLayer.DataTransferObject;
using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AuthorizationMSSQLService : IAuthorizationService<AuthorizationMSSQLDataDTO>
    {
        public void Connect(AuthorizationMSSQLDataDTO dataAuthorization)
        {
            throw new NotImplementedException(message: "Ща все будет");
        }

        public void Disconect()
        {
            throw new NotImplementedException(message: "Ща все будет");
        }

        public DataConnectionDBDTO GetStatusConnect()
        {
            return new DataConnectionDBDTO() { DataSourceName = "Pass", IsConnected = true };
        }
    }
}
