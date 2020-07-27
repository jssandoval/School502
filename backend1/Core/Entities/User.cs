using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Core.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Core.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ChangePassword { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModification { get; set; }
        public DateTime DateLastLogin { get; set; }
        public DateTime DateLastChange { get; set; }
        public int DaysChangePassword { get; set; }
        public ICollection<UserMenu> MenuUser { get; set; }
        public ICollection<UserSchool> SchoolUser { get; set; }
        //public RoleType Role { get; set; }
    }
}
