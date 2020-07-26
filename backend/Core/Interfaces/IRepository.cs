using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Core.Entities;

namespace backend.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(string id);
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(string id);
    }
}
