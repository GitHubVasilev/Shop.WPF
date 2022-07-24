using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOleDBContext<T>
        where T: BaseEntity
    {
        Task Connect(string initalCatalog, string login, string password);
        Task Disconnect();
        bool IsEnabled { get; }
        string DatabaseName { get; }
        Task<IEnumerable<T>> GetTable();
        Task RunCommand(string command);
    }
}
