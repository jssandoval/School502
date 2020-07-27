using System;
using System.Threading.Tasks;
using backend.Core.Entities;

namespace backend.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<User> GetLoginByCredentials(UserLogin userLogin);
    }
}
