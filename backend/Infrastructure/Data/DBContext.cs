using System;
using backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using backend.Infrastructure.Data.Configurations;
using MongoDB.Driver;

namespace backend.Infrastructure.Data
{
    public partial class DBContext : DbContext
    {
        private IConfiguration _configuration;

        //private readonly IMongoDatabase _database = null;
        MongoClient client;
        IMongoDatabase database;

        //Documents
        public readonly IMongoCollection<School> Schools;

        public DBContext(IOptions<DBSettings> settings, IConfiguration Configuration)
        {
            _configuration = Configuration;

            //var client = new MongoClient(settings.Value.ConnectionString);
            //_database = new MongoClient(settings.Value.ConnectionString).GetDatabase(settings.Value.DatabaseName);
            //Users = _database.GetCollection<User>("User");
            client = new MongoClient(_configuration.GetConnectionString("schoolDB"));
            database = client.GetDatabase(_configuration.GetConnectionString("DatabaseName"));

            Schools = database.GetCollection<School>("Schools");

            //if (client != null)
            //    _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        //public virtual DbSet<School> School { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration( new SchoolConfiguration());
        }
    }
}
