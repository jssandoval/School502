using System;
using System.Threading.Tasks;
using backend.Core.Entities;
using backend.Infrastructure.Data;
using backend.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.Infrastructure.Repositories
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