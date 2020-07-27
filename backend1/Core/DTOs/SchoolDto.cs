using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Core.DTOs
{
    public class SchoolDto
    {
        /// <summary>
        /// Autogenated Id for School entry
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Name of School
        /// </summary>
        public string Name { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    }       
}