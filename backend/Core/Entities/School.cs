using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Core.Entities
{
    public class School{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public ICollection<SchoolAddress> Address { get; set; }
        public ICollection<SchoolSocial> SocialSchool { get; set; }
        public ICollection<SchoolContact> ContactSchool { get; set; } 
        public bool? Status { get; set; }
    }       
}