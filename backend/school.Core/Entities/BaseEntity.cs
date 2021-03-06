﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace school.Core.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
    }
}
