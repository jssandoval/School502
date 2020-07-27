using System.Threading.Tasks;
using backend.Core.Entities;

namespace backend.Infrastructure.Interfaces
{
    public interface ISecurityRepository
    {

        Task<User> GetLoginByCredentials(UserLogin login);
    }
}