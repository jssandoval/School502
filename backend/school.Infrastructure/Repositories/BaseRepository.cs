using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using school.Core.Entities;
using school.Core.Interfaces;
using school.Infrastructure.Data;

namespace school.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DBContext _context = null;
        //protected readonly DbSet<T> _entities;
        public IMongoCollection<T> _entities { get; private set; }
        private IConfiguration _configuration;

        public BaseRepository(DBContext context, IConfiguration Configuration)
        {

            _configuration = Configuration;
            //IOptions<DBSettings> settings
            //_context = new DBContext(settings, _configuration);
            _context = context;
            _entities = _context.DbSet<T>();
            //_context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsQueryable(); //.Find(e => e.Status == true).ToListAsync();
        } 

        public async Task<T> GetById(string id)
        {
            return await _entities.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(T entity)
        {
            await _entities.InsertOneAsync(entity);
        }

        public async Task<bool> Update(T entity)
        {
            var result = await _entities.ReplaceOneAsync(sc => sc.Id == entity.Id, entity);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _entities.DeleteOneAsync(sc => sc.Id == id);
            return result.DeletedCount > 0;            //T entity = await GetById(id);
            //_entities.Remove(entity);
            //await Task.Delay(1);
            //return true;
        }
    }

}
