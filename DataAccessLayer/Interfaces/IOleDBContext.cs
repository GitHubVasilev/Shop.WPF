using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IOleDBContext<T>
        where T: BaseEntity
    {
        void Connect(string initalCatalog, string login, string password);
        void Disconnect();
        bool IsEnabled { get; }
        string DatabaseName { get; }
        IEnumerable<T> GetTable();
        void RunCommand(string command);
    }
}
