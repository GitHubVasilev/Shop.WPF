using BusinessLogicLayer.DataTransferObject;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAuthorizationService<T> where T : BaseAuthorizationDB
    {
        delegate void Connection(IAuthorizationService<T> sender, DataConnectionDBDTO eventArgs);
        delegate void Disconnection(IAuthorizationService<T> sender, DataConnectionDBDTO eventArgs);
        public event Connection? ConnectionEvent;
        public event Disconnection? DisconnectonEvent;
        void Connect(T dataAuthorization);
        void Disconect();
        DataConnectionDBDTO GetStatusConnect();
    }
}
