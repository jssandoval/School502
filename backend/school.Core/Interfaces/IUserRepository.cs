using System.Collections.Generic;
using System.Threading.Tasks;
using school.Core.Entities;

namespace school.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
    }
}
