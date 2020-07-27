using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using school.Core.Entities;
using school.Core.Interfaces;
using school.Infrastructure.Data;

namespace school.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region variables
        private readonly DBContext _context = null;
        private IConfiguration _configuration;
        #endregion

        #region constructor
        public UserRepository(IOptions<DBSettings> settings, IConfiguration Configuration)
        {
            _configuration = Configuration;
            _context = new DBContext(settings, _configuration);
        }
        #endregion

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Find(e => e.Status == true).ToListAsync();
            return users;
        }

        public async Task<User> GetUser(string id)
        {
            var user = await _context.Users.Find(e => e.Id == id).FirstOrDefaultAsync();
            return (User)user;
        }
    }
}
