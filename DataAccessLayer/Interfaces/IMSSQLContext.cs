using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IMSSQLContext<T>
        where T : BaseEntity
    {
        void Connect(string initialCatalog);
        void Disconnect();
        bool IsEnabled { get; }
        string DatabaseName { get; }
        IEnumerable<T> GetTable();
        void RunCommand(string command);
    }
}
