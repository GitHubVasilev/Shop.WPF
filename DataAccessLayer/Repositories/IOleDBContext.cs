namespace DataAccessLayer.Repositories
{
    public interface IOleDBContext
    {
        void Connect(string initalCatalog, string login, string password);
        void Disconnect();
        bool IsEnabled { get; }
    }
}
