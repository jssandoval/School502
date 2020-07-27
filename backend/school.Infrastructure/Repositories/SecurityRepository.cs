using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using school.Core.Entities;
using school.Core.Interfaces;
using school.Infrastructure.Data;

namespace school.Infrastructure.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        #region variables
        private readonly DBContext _context = null;
        private IConfiguration _configuration;
        #endregion

        public SecurityRepository(DBContext context, IConfiguration Configuration)
        {
            _configuration = Configuration;
            _context = context;
        }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            var user = await _context.Users.Find(e => e.Email == login.User).FirstOrDefaultAsync();
            return user; // && e.Password == login.Password).FirstOrDefaultAsync();
        }
    }
}