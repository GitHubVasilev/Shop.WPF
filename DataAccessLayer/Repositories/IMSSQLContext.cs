using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal interface IMSSQLContext
    {
        void Connect(string initialCatalog);
        void Disconnect();
        bool IsEnabled { get; }
    }
}
