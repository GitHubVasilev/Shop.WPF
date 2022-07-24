using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IMSSQLContext<T>
        where T : BaseEntity
    {
        Task Connect(string initialCatalog);
        Task Disconnect();
        bool IsEnabled { get; }
        string DatabaseName { get; }
        Task<IEnumerable<T>> GetTable();
        Task RunCommand(string command);
    }
}
