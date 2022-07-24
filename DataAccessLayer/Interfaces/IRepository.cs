using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(Func<T,bool> predicate);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Clear();
    }
}
