using backend.Core.Entities;
using backend.Core.Interfaces;
using backend.Infrastructure.Data;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace backend.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        #region variables
        private readonly DBContext _context = null;
        private IConfiguration _configuration;

        //private readonly IMongoCollection<School> school;

        //MongoClient client;
        //IMongoDatabase database;
        #endregion

        #region constructor
        public SchoolRepository(IOptions<DBSettings> settings, IConfiguration Configuration)
        {
            _configuration = Configuration;
            _context = new DBContext(settings, _configuration);

            //_userCollection = _context.GetCollection<User>("User");
            //_userQueryable = _userCollection.AsQueryable();

            //client = new MongoClient(_configuration.GetConnectionString("schoolDB"));
            //database = client.GetDatabase("school");
            //school = database.GetCollection<School>("school");

        }
        #endregion

        public async Task<IEnumerable<School>> GetSchools()
        {
            // Console.Write("llego a get");
            // var school = Enumerable.Range(1,10).Select(x => new School{
            //     SchoolId = x,
            //     Description = $"Description {x}",
            //     Name = $"name {x}"
            // });
            //var school = await _context.School.FindAsync();
            var school = await _context.Schools.Find(e => e.Status == true).ToListAsync();
            // Console.Write(school);
            // await Task.Delay(1);
            return school;
        }

        public async Task<School> GetSchool(string id)
        {
            // Console.Write(id);
            var school = _context.Schools.Find(e => e.Id == id).FirstOrDefault();
            // Console.Write(school);
            await Task.Delay(1);
            return (School)school;
        }

        public async Task InsertSchool(School school)
        {
            await _context.Schools.InsertOneAsync(school);
            // await Task.Delay(1);
        }
    }    
}