using System;
using System.Threading.Tasks;
using backend.Core.Entities;

namespace backend.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //ISchoolRepository SchoolRepository

        IRepository<School> SchoolRepository { get; }

        IRepository<User> UserRepository { get; }

        //ISecurityRepository SecurityRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
