using System.Threading.Tasks;
using school.Core.Entities;
using school.Core.Interfaces;

namespace school.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
        }

        //public async Task RegisterUser(UserLogin security)
        //{
        //    await _unitOfWork.SecurityRepository.Add(security);
        //    await _unitOfWork.SaveChangesAsync();
        //}
    }
}
