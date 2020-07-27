using System;
using System.Threading.Tasks;
using backend.Core.Entities;
using backend.Infrastructure.Interfaces;

namespace backend.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //ISchoolRepository SchoolRepository

        IRepository<School> SchoolRepository { get; }

        IRepository<User> UserRepository { get; }

        ISecurityRepository SecurityRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
