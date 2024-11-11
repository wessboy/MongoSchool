using MongoDB.Bson.Serialization;
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
                cm.MapIdField(st => st.Id).SetSerializer(new MongoDB.Bson.Serialization.Serializers.ObjectIdSerializer());
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
