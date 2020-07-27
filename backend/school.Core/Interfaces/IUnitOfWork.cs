using System;
using System.Threading.Tasks;
using school.Core.Entities;

namespace school.Core.Interfaces
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
