using MongoDB.Driver;
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
        }

        public IMongoCollection<T> setCollection<T>(string collectionName) 
        { 
           var collection = _database.GetCollection<T>(collectionName);

            return collection;
        }
    }
}
