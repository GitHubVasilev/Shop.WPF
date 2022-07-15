using BusinessLogicLayer.DataTransferObject;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAuthorizationService<T> where T : BaseAuthorizationDB
    {
        void Connect(T dataAuthorization);
        void Disconect();
        DataConnectionDBDTO GetStatusConnect();
    }
}
