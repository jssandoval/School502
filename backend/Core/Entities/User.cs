using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModification { get; set; }
        public DateTime DateLastLogin { get; set; }
        public DateTime DateLastChange { get; set; }
        public int DaysChangePassword { get; set; }
    }
}
