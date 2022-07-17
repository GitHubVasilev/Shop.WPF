using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T,bool> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Clear();
    }
}
