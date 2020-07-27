using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using school.Core.Entities;
using school.Core.Exceptions;
using school.Core.Interfaces;
using school.Infrastructure.Data;

namespace school.Infrastructure.Repositories
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
            var school = await _context.Schools.Find(e => e.Id == id).FirstOrDefaultAsync();
            // Console.Write(school);
            return (School)school;
        }

        public async Task InsertSchool(School school)
        {
            await _context.Schools.InsertOneAsync(school);
            // await Task.Delay(1);
        }

        public async Task<bool> UpdateSchool(School school)
        {
            School currentSchool = await GetSchool(school.Id);
            bool result = true;
            if (currentSchool != null)
            { 
                currentSchool.Name = school.Name;
                currentSchool.Description = school.Description;
                currentSchool.Logo = school.Logo;
                currentSchool.Status = school.Status;

                try
                {
                    await _context.Schools.ReplaceOneAsync(sc => sc.Id == school.Id, school);
                }
                catch(Exception e)
                {
                    throw new BusinessException("NO update " + e.Message);
                    //result = false;
                }
            }
            else
            {
                result = false;
            }
            //.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteSchool(string id)
        {
            try
            {
                await _context.Schools.DeleteOneAsync(sc => sc.Id == id);
                return true;
            }
            catch (Exception e)
            {
                throw new BusinessException("NO Delete " + e.Message);
                //result = false;
            }
            //.SaveChangesAsync();
        }
    }
}