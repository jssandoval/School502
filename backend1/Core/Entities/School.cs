using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Core.Entities
{
    [Table("Schools")]
    public class School : BaseEntity
    {
        public string Description { get; set; }
        public string Logo { get; set; }
        public ICollection<SchoolAddress> Address { get; set; }
        public ICollection<SchoolSocial> SocialSchool { get; set; }
        public ICollection<SchoolContact> ContactSchool { get; set; } 
    }       
}