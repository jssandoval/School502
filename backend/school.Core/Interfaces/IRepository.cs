using System.Collections.Generic;
using System.Threading.Tasks;
using school.Core.Entities;

namespace school.Core.Interfaces
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
