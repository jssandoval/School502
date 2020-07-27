using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using school.Core.Entities;
using school.Core.Interfaces;
using school.Infrastructure.Data;

namespace school.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region variables
        private readonly DBContext _context = null;
        //private readonly IOptions<DBSettings> = null;
        private IConfiguration _configuration;

        private readonly IRepository<School> _schoolRepository = null;
        private readonly IRepository<User> _userRepository = null;
        private readonly ISecurityRepository _securityRepository = null;
        #endregion

        #region constructor
        public UnitOfWork(IOptions<DBSettings> settings, IConfiguration Configuration)
        {
            _configuration = Configuration;
            //__settings = settings;
            _context = new DBContext(settings, _configuration);
        }
        #endregion

        public IRepository<School> SchoolRepository => _schoolRepository ?? new BaseRepository<School>(_context, _configuration) ;

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context, _configuration);

        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context, _configuration);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
