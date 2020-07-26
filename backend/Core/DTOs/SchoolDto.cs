using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Core.DTOs
{
    public class SchoolDto{
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    }       
}