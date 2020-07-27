using System.Threading.Tasks;
using school.Core.Entities;

namespace school.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<User> GetLoginByCredentials(UserLogin userLogin);
    }
}
