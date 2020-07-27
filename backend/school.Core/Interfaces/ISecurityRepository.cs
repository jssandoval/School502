using System.Threading.Tasks;
using school.Core.Entities;

namespace school.Core.Interfaces
{
    public interface ISecurityRepository
    {

        Task<User> GetLoginByCredentials(UserLogin login);
    }
}