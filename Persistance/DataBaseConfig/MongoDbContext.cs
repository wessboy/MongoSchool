using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DataBaseConfig
{
     public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database) 
        { 
           _database = database;

            BsonClassMap.RegisterClassMap<Student>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(st => st.Id).SetSerializer(new ObjectIdStringSerializer());
                cm.MapField(st => st.FirstName).SetIsRequired(true);
                cm.MapField(st => st.LastName).SetIsRequired(true);
                cm.MapField(st => st.Major);
                

            });
        }

        public IMongoCollection<T> setCollection<T>(string collectionName) 
        { 
           var collection = _database.GetCollection<T>(collectionName);

            return collection;
        }
    }
}
